package main

import (
	"fmt"
	"os"
	"path/filepath"
)

//Classes hold a list of all classes in the SDK (using filename scan)
type Classes struct {
	classes []string
}

func (c *Classes) buildList(rootpath string) error {
	c.classes = make([]string, 0)
	fmt.Printf("Scanning '%v'... ", rootpath)
	err := filepath.Walk(rootpath, c.walkfunc)
	if err != nil {
		return err
	}
	fmt.Printf("%v classes found\n", len(c.classes))
	return nil
}

func (c *Classes) walkfunc(path string, info os.FileInfo, err error) error {
	if !info.IsDir() {
		if filepath.Ext(path) == ".cs" {
			className := filepath.Base(path)
			className = className[:len(className)-3]
			c.classes = append(c.classes, filepath.Base(className))
		}
	}
	return nil
}

//Has is true if SDK has the class name provided
func (c *Classes) Has(className string) bool {
	for _, name := range c.classes {
		if name == className {
			return true
		}
	}
	return false
}
