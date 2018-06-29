#!/bin/bash

set -e

echo "Building support"

# "nuget restore" fails if local package source directories don't exist.
mkdir -p NuPkgs/Support

# Final output directory of NuPkgs.
NUPKG_DIR="$(pwd)/NuPkgs/Support"
# Final output directory of NuPkgs.
NUSPEC_PATH=`pwd`/deploy/.nuspec
# Build configuration to build/pack.
BUILD_CONFIGURATION=Release

echo $NUPKG_DIR
ls -la $NUPKG_DIR

# Forces sourcelink to work during the build.
export CI=true

#dotnet build -c $BUILD_CONFIGURATION src/Google.Analytics.SDK.Core
#dotnet build -c $BUILD_CONFIGURATION tests/Google.Analytics.SDK.Tests
#dotnet test -c $BUILD_CONFIGURATION tests/Google.Analytics.SDK.Tests 
#dotnet pack src/Google.Analytics.SDK.Core --configuration $BUILD_CONFIGURATION --no-restore --no-build --output $NUPKG_DIR /p:NuspecFile=deploy/.nuspec

