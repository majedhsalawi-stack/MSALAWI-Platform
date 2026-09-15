#!/usr/bin/env bash
set -euo pipefail

dotnet restore MSALAWI.Platform.slnx
dotnet build MSALAWI.Platform.slnx --configuration Release --no-restore
dotnet test MSALAWI.Platform.slnx --configuration Release --no-build

pushd source/Presentation/Web >/dev/null
npm ci
npm run build
popd >/dev/null
