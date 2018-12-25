package main

import (
	"fmt"
	"strings"

	"github.com/iancoleman/strcase"
)

//Pagination ...
type Pagination struct {
	InputToken  string
	LimitKey    string
	OutputToken string
	ResultKey   []string
}

//Operation ...
type Operation struct {
	Parent        *Service
	Name          string
	Description   string
	RequestClass  string
	ResponseClass string
	ResponseCode  string
	Method        string
	RequestURI    string
	Pagination    *Pagination
}

//Service ...
type Service struct {
	ServiceID      string
	EndPointPrefix string
	Filename       string
	Basefolder     string
	Abbreviation   string
	FullName       string
	Operations     []*Operation
	shapes         map[string]interface{}
}

//HasPagination ...
func (s *Service) HasPagination() bool {
	for _, o := range s.Operations {
		if o.Pagination != nil {
			return true
		}
	}
	return false
}

//ServiceName ...
func (s *Service) ServiceName() string {
	var serviceName string
	if s.Abbreviation != "" {
		serviceName = strcase.ToCamel(s.Abbreviation)
	} else {
		serviceName = strcase.ToCamel(s.FullName)
	}
	serviceName = strings.Replace(serviceName, "AWS", "", -1)
	serviceName = strings.Replace(serviceName, "Amazon", "", -1)
	switch serviceName {
	case "ElasticsearchService":
		return "Elasticsearch"
	case "Health":
		return "AWSHealth"
	case "IAM":
		return "IdentityManagement"
	case "KMS":
		return "KeyManagementService"
	case "SES":
		return "SimpleEmail"
	case "SFN":
		return "StepFunctions"
	case "SMS":
		return "ServerMigrationService"
	case "SNS":
		return "SimpleNotificationService"
	case "SSM":
		return "SimpleSystemsManagement"
	default:
		return serviceName
	}
}

//ClientClassName ...
func (s *Service) ClientClassName() string {
	return fmt.Sprintf("Amazon%sClient", s.ServiceName())
}

//NewOperation creates new operation
func (s *Service) NewOperation(opName string) *Operation {
	o := &Operation{
		Name:   opName,
		Parent: s,
	}
	s.Operations = append(s.Operations, o)
	return o
}

//ShapeRequiredParams returns the list of required params for shape
func (s *Service) ShapeRequiredParams(shape string) string {
	m := s.shapes[shape].(map[string]interface{})
	params, ok := m["required"]
	if !ok {
		return ""
	}
	pstr := fmt.Sprintf("%v", params)
	if pstr == "" || pstr == "[]" {
		return ""
	}
	return pstr
}

//ClassName ...
func (o *Operation) ClassName() string {
	//LambaListFunctionsOperation
	return fmt.Sprintf("%v%vOperation", o.Parent.ServiceName(), o.Name)

}

//RequestClassName normalizes the request clsas name
func (o *Operation) RequestClassName() string {
	res := strings.Replace(o.RequestClass, "Input", "Request", 1)
	if !strings.HasSuffix(res, "Request") {
		res += "Request"
	}
	return res
}

//ResponseClassName normalizes the ResponseClassName
func (o *Operation) ResponseClassName() string {
	res := strings.Replace(o.ResponseClass, "Output", "Response", 1)
	if !strings.HasSuffix(res, "Response") {
		res += "Response"
	}
	return res
}

//SetResultKeys sets results keys from map item
func (p *Pagination) SetResultKeys(item interface{}) {
	p.ResultKey = make([]string, 0)
	rkaArray, ok := item.([]string)
	if ok {
		for _, k := range rkaArray {
			p.ResultKey = append(p.ResultKey, strcase.ToCamel(k))
		}
		return
	}
	rkStr, ok := item.(string)
	if ok {
		p.ResultKey = append(p.ResultKey, strcase.ToCamel(rkStr))
	}
}

//EnsureResultKey if results key not found in pagination, try to search for it in shapes.
func (p *Pagination) EnsureResultKey(s *Service, o *Operation) {
	if len(p.ResultKey) == 0 {
		members, ok := s.shapes[o.ResponseClass].(map[string]interface{})
		if ok {
			for member := range members["members"].(map[string]interface{}) {
				if member != "NextToken" &&
					member != "TotalCount" &&
					member != "Marker" &&
					member != "IsTruncated" &&
					member != "nextToken" &&
					member != "MaxResults" &&
					member != "NextPageToken" &&
					member != "NextMarker" &&
					member != "Status" &&
					member != "PageToken" &&
					member != "TotalResultsCount" {
					p.ResultKey = append(p.ResultKey, strcase.ToCamel(member))
				}
			}
		}
	}
}
