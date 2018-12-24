package main

import (
	"flag"
	"log"
)

func main() {
	g, err := NewGenerator()
	if err != nil {
		log.Println(err)
	}
	flag.StringVar(&g.OutputFolder, "output", "generated", "the path to generate output files")
	flag.StringVar(&g.SdkRoot, "sdkroot", "", "path to aws dotnet sdk sources root")
	flag.Parse()

	if g.SdkRoot == "" {
		flag.Usage()
		return
	}
	log.Println(g.Generate())
}
