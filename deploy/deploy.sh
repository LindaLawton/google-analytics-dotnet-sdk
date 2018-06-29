ApiKey=$1
NUPKG_DIR=$2

echo "Build start"
echo $NUPKG_DIR

nuget pack .nuspec -Verbosity detailed

ls -la $NUPKG_DIR/*.nupkg

# nuget push $NUPKG_DIR/*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source https://api.nuget.org/v3/index.json

