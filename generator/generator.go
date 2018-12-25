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

	strip "github.com/grokify/html-strip-tags-go"
	// => strip
)

//Generator ...
type Generator struct {
	OutputFolder                string
	SdkRoot                     string
	Services                    []*Service
	PaginationOperationTemplate *template.Template
	SingleOperationTemplate     *template.Template
}

//NewGenerator ...
func NewGenerator() (*Generator, error) {
	g := &Generator{}
	g.Services = make([]*Service, 0)
	var err error
	g.PaginationOperationTemplate, err = g.readTemplate("operation_pagination.tmpl")
	if err != nil {
		return nil, err
	}
	g.SingleOperationTemplate, err = g.readTemplate("operation_single.tmpl")
	if err != nil {
		return nil, err
	}
	return g, nil
}

func (g *Generator) readTemplate(filename string) (*template.Template, error) {
	data, err := ioutil.ReadFile(filename)
	if err != nil {
		return nil, err
	}
	templateName := filepath.Base(filename)
	t, err := template.New(templateName).Parse(string(data))
	if err != nil {
		return nil, err
	}
	return t, nil
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

func (g *Generator) processOperations(s *Service, operations map[string]interface{}) error {
	for k, v := range operations {
		oper := s.NewOperation(k)
		oper.Description = fmt.Sprintf("%v", v.(map[string]interface{})["documentation"])
		input := g.keyAsMap(v, "input")
		if input != nil && input["shape"] != nil {
			oper.RequestClass = fmt.Sprintf("%v", input["shape"])
		} else {
			log.Printf("Operation %v does not have a request class", oper.Name)
			continue
		}
		required := s.ShapeRequiredParams(oper.RequestClass)
		if required != "" {
			log.Printf("Operation '%v' shape '%v' needs params :'%v'", oper.Name, oper.RequestClass, required)
			continue
		}
		output := g.keyAsMap(v, "output")
		if output != nil && output["shape"] != nil {
			oper.ResponseClass = fmt.Sprintf("%v", output["shape"])
		}
		ht := g.keyAsMap(v, "http")
		if ht != nil {
			rc := ht["responseCode"]
			if rc == nil {
				oper.ResponseCode = "200"
			} else {
				oper.ResponseCode = fmt.Sprintf("%v", ht["responseCode"])
			}
			oper.RequestURI = fmt.Sprintf("%v", ht["requestUri"])
			oper.Method = fmt.Sprintf("%v", ht["method"])
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
		if items["input_token"] != nil {
			p.InputToken = fmt.Sprintf("%v", items["input_token"])
		}
		if items["limit_key"] != nil {
			p.LimitKey = fmt.Sprintf("%v", items["limit_key"])
		}
		if items["output_token"] != nil {
			p.OutputToken = fmt.Sprintf("%v", items["output_token"])
		}
		p.SetResultKeys(items["result_key"])
		g.SetPagination(p, funcName, serviceFolder)
	}
	return nil
}

//SetPagination ...
func (g *Generator) SetPagination(p *Pagination, funcName string, serviceFolder string) {
	for i := range g.Services {
		if g.Services[i].Basefolder == serviceFolder {
			for j := range g.Services[i].Operations {
				if g.Services[i].Operations[j].Name == funcName {
					p.EnsureResultKey(g.Services[i], g.Services[i].Operations[j])
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

	var apiObject map[string]interface{}
	err = json.Unmarshal(data, &apiObject)
	if err != nil {
		return err
	}
	s.shapes = g.keyAsMap(apiObject, "shapes")
	metadata := g.keyAsMap(apiObject, "metadata")
	operations := g.keyAsMap(apiObject, "operations")
	if metadata != nil {
		if metadata["serviceAbbreviation"] != nil {
			s.Abbreviation = fmt.Sprintf("%v", metadata["serviceAbbreviation"])
		}
		if metadata["serviceFullName"] != nil {
			s.FullName = fmt.Sprintf("%v", metadata["serviceFullName"])
		}
		s.ServiceID = fmt.Sprintf("%v", metadata["serviceId"])
		s.EndPointPrefix = fmt.Sprintf("%v", metadata["endpointPrefix"])
		g.processOperations(s, operations)
	}

	return nil
}

func (g *Generator) walkfunc(path string, info os.FileInfo, err error) error {
	if !info.IsDir() {
		log.Printf("Processing %v", path)
		if strings.HasSuffix(info.Name(), ".normal.json") {
			g.processAPIFile(path)
		} else if strings.HasSuffix(info.Name(), "paginators.json") {
			g.processPaginatorFile(path)
		}
	}

	return nil
}

func (g *Generator) renderOperationClass(s *Service, o *Operation) error {
	data := make(map[string]interface{})
	data["ServiceName"] = s.ServiceName()
	data["ServiceID"] = s.ServiceID
	data["OperationClassName"] = o.ClassName()
	data["ClientClassName"] = s.ClientClassName()
	data["ReqeustClassName"] = o.RequestClass
	data["ResponseClassName"] = o.ResponseClass
	if o.Pagination.LimitKey != "" {
		data["PagingationLimitKey"] = o.Pagination.LimitKey
	}
	data["PaginationResultKey"] = o.Pagination.ResultKey
	data["OperationName"] = o.Name
	if o.ResponseCode == "" {
		data["ResponseCode"] = "200"
	} else {
		data["ResponseCode"] = o.ResponseCode
	}

	for k, v := range data {
		if v == nil || v == "" {
			return fmt.Errorf("Missing value '%v' in %v", k, data)
		}
	}
	data["OperationDescription"] = strip.StripTags(o.Description)
	data["RequestURI"] = o.RequestURI
	data["Method"] = o.Method
	fileName := filepath.Join(g.OutputFolder, fmt.Sprintf("%v.cs", o.ClassName()))
	log.Printf("generating %v", fileName)
	file, err := os.Create(fileName)
	if err != nil {
		return err
	}
	defer file.Close()

	if (o.Pagination.InputToken == "") || (o.Pagination.OutputToken == "") {
		return g.SingleOperationTemplate.Execute(file, data)
	} else {
		data["PagingationInputToken"] = o.Pagination.InputToken
		data["PagingationOutputToken"] = o.Pagination.OutputToken
		return g.PaginationOperationTemplate.Execute(file, data)
	}
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
