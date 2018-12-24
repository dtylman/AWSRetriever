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
	ResultKey   string
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
	return serviceName
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

//ClassName ...
func (o *Operation) ClassName() string {
	//LambaListFunctionsOperation
	return fmt.Sprintf("%v%vOperation", o.Parent.ServiceName(), o.Name)

}
