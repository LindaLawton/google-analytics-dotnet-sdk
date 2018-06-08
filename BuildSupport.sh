#!/bin/bash

set -e

# "nuget restore" fails if local package source directories don't exist.
mkdir -p NuPkgs/Support

# Final output directory of NuPkgs.
NUPKG_DIR=`pwd`/NuPkgs/Support
# Build configuration to build/pack.
BUILD_CONFIGURATION=Release

# Forces sourcelink to work during the build.
export CI=true

dotnet restore Src/Google.Analytics.SDK.sln
dotnet build Src/Google.Analytics.SDK.sln --configuration $BUILD_CONFIGURATION --no-restore

