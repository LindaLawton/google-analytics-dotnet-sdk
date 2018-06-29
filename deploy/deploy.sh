ApiKey=$1


echo "Deploy start."
echo $ApiKey

#nuget pack .nuspec -Verbosity detailed

#nuget push $NUPKG_DIR/*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source https://api.nuget.org/v3/index.json

