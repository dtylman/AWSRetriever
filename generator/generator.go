package main

import (
	"encoding/json"
	"fmt"
	"html/template"
	"io/ioutil"
	"log"
	"os"
	"path/filepath"
	"strings"
)

//Generator ...
type Generator struct {
	OutputFolder      string
	SdkRoot           string
	Services          []*Service
	OperationTemplate *template.Template
}

//NewGenerator ...
func NewGenerator() (*Generator, error) {
	g := &Generator{}
	g.Services = make([]*Service, 0)
	data, err := ioutil.ReadFile("operation.tmpl")
	if err != nil {
		return nil, err
	}
	g.OperationTemplate, err = template.New("operation").Parse(string(data))
	if err != nil {
		return nil, err
	}
	return g, nil
}

func (g *Generator) keyAsMap(obj interface{}, key string) map[string]interface{} {
	m, ok := obj.(map[string]interface{})
	if !ok {
		return nil
	}
	val, ok := m[key]
	if !ok {
		return nil
	}
	return val.(map[string]interface{})
}

func (g *Generator) processOprations(s *Service, operations map[string]interface{}) error {
	for k, v := range operations {
		oper := s.NewOperation(k)
		input := g.keyAsMap(v, "input")
		if input != nil && input["shape"] != nil {
			oper.Input = fmt.Sprintf("%v", input["shape"])
		}
		output := g.keyAsMap(v, "output")
		if output != nil && output["shape"] != nil {
			oper.Output = fmt.Sprintf("%v", output["shape"])
		}
		ht := g.keyAsMap(v, "http")
		if ht != nil {
			oper.ResponseCode = fmt.Sprintf("%v", ht["responseCode"])
		}
	}
	return nil
}

func (g *Generator) processPaginatorFile(path string) error {
	data, err := ioutil.ReadFile(path)
	if err != nil {
		return err
	}
	var obj map[string]interface{}
	err = json.Unmarshal(data, &obj)
	if err != nil {
		return err
	}
	serviceFolder := filepath.Dir(path)
	pobject := g.keyAsMap(obj, "pagination")

	for funcName, v := range pobject {
		items := v.(map[string]interface{})
		p := &Pagination{}
		p.InputToken = fmt.Sprintf("%v", items["input_token"])
		p.LimitKey = fmt.Sprintf("%v", items["limit_key"])
		p.OutputToken = fmt.Sprintf("%v", items["output_token"])
		p.ResultKey = fmt.Sprintf("%v", items["result_key"])
		g.setPagination(p, funcName, serviceFolder)
	}
	return nil
}

func (g *Generator) setPagination(p *Pagination, funcName string, serviceFolder string) {
	for i := range g.Services {
		if g.Services[i].Basefolder == serviceFolder {
			for j := range g.Services[i].Operations {
				if g.Services[i].Operations[j].Name == funcName {
					g.Services[i].Operations[j].Pagination = p
				}
			}
		}
	}
}

func (g *Generator) addService() *Service {
	s := &Service{}
	s.Operations = make([]*Operation, 0)
	g.Services = append(g.Services, s)
	return s
}

func (g *Generator) processAPIFile(path string) error {
	s := g.addService()
	s.Basefolder = filepath.Dir(path)
	s.Filename = path
	data, err := ioutil.ReadFile(path)
	if err != nil {
		return err
	}
	var obj map[string]interface{}
	err = json.Unmarshal(data, &obj)
	if err != nil {
		return err
	}
	metadata := g.keyAsMap(obj, "metadata")
	if metadata != nil {
		if metadata["serviceAbbreviation"] != nil {
			s.Abbreviation = fmt.Sprintf("%v", metadata["serviceAbbreviation"])
		}
		if metadata["serviceFullName"] != nil {
			s.FullName = fmt.Sprintf("%v", metadata["serviceFullName"])
		}
		g.processOprations(s, g.keyAsMap(obj, "operations"))
	}

	return nil
}

func (g *Generator) walkfunc(path string, info os.FileInfo, err error) error {
	if !info.IsDir() {
		log.Printf("Processing %v", path)
		if strings.HasSuffix(info.Name(), "api.json") {
			g.processAPIFile(path)
		} else if strings.HasSuffix(info.Name(), "paginators.json") {
			g.processPaginatorFile(path)
		}
	}

	return nil
}

func (g *Generator) renderOperationClass(s *Service, o *Operation) error {
	//LambaListFunctionsOperation
	fileName := filepath.Join(g.OutputFolder, fmt.Sprintf("%v.cs", o.ClassName()))
	log.Printf("generating %v", fileName)
	file, err := os.Create(fileName)
	if err != nil {
		return err
	}
	defer file.Close()
	data := make(map[string]interface{})
	data["ServiceName"] = s.ServiceName()
	data["OperationClassName"] = o.ClassName()
	data["ClientClassName"] = s.ClientClassName()
	data["ReqeustClassName"] = o.Input
	data["PagingationInputToken"] = o.Pagination.InputToken
	data["ResponseClassName"] = o.Output
	data["PagingationOutputToken"] = o.Pagination.OutputToken
	data["PagingationLimitKey"] = o.Pagination.LimitKey
	data["PaginationResultKey"] = o.Pagination.ResultKey
	data["OperationName"] = o.Name
	for k, v := range data {
		if v == nil || v == "" {
			return fmt.Errorf("Missing value '%v' in %v", k, data)
		}
	}
	return g.OperationTemplate.Execute(file, data)
}

//Generate ...
func (g *Generator) Generate() error {
	modelPath := filepath.Join(g.SdkRoot, "generator", "ServiceModels")
	_, err := os.Stat(modelPath)
	if err != nil {
		return err
	}
	err = filepath.Walk(modelPath, g.walkfunc)
	if err != nil {
		return err
	}
	err = os.MkdirAll(g.OutputFolder, 0755)
	if err != nil {
		return err
	}
	for _, s := range g.Services {
		for _, o := range s.Operations {
			if o.Pagination != nil {
				err = g.renderOperationClass(s, o)
				if err != nil {
					log.Println(err)
				}
			}
		}
	}
	return err
}
