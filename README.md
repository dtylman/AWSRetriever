 AWSRetriever

Lists all resources in a AWS account.

[![Build Status](https://dev.azure.com/dtylman/heaven/_apis/build/status/dtylman.heaven?branchName=master)](https://dev.azure.com/dtylman/heaven/_build/latest?definitionId=1?branchName=master)

## Features

* Supports over 390 APIs from over 70 services, all regions

* Objects saved in JSON format

* Define and save profiles for specific service queries

* Runs a single operation

## Download & Run

Download [the latest](https://github.com/dtylman/AWSRetriever/releases/) for Windows or Linux.

### Windows

1. (Requires .NET 4.5)
1. Create a folder `AWSRetriever`
1. Unzip to folder.
1. Run `AWSRetriver.exe`

### Linux / Ubuntu

Make sure mono is installed:

```bash
sudo apt-get install mono-runtime
```

```bash
mkdir awsretriver
cd awsretriver
unzip path_to_downloaded_awsretriver.zip 
mono AWSRetriver.exe
```

## Screenshots

### Main Screen with some data

![main-screen](./doc/main-screen.PNG)

### Profile Editor

![profile-editor](./doc/profile-editor1.PNG)

### Lanching a specific API

![single-operation](./doc/single-operation.PNG)


### Thanks

* [Modern UI Done RIght](https://github.com/NickAcPT/ModernUIDoneRight)
* [Icons8](https://icons8.com/license/)
