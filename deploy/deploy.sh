ApiKey=$1
NUPKG_DIR=$2

nuget pack .nuspec -Verbosity detailed

nuget push $NUPKG_DIR/*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source https://api.nuget.org/v3/index.json

