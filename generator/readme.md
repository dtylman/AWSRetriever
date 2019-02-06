# Generator

Generates CloudOps classes from AWS sdk sources.

SDKROOT is this: https://github.com/aws/aws-sdk-net

Build & Run:

```bash
go get ./...
go build 
./generator -output ../CloudOps/ -sdkroot ../aws-sdk-net/
```

Apply the patches:

```bash
cd ../CloudOps/Generated
patch -R -p3 < ../../generator/first.patch
.
. //second.patch and so forth 
.
```

This also generates `OperationFactory.cs` and `itemgroup.txt`

Item group file should be copied to `CloudOps.csproj` to add the files quickly.

`OperationFactory.cs` is copied to `CloudsOp` project also.

Creating patch files:

```bash
diff -Naur <new-path> ../CloudOps/Generated > [number].patch
```

## AWS SDK Release

Based on AWS SDK [3.3.434.0](https://github.com/aws/aws-sdk-net/releases/tag/3.3.434.0)

Sources [link](https://github.com/aws/aws-sdk-net/archive/3.3.434.0.tar.gz) for the generator.