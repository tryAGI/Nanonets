dotnet tool install --global autosdk.cli --prerelease
rm -rf Generated
curl -o openapi.yaml https://raw.githubusercontent.com/NanoNets/api-docs/main/nanonets_openapi_3.1.0.yaml
autosdk generate openapi.yaml \
  --namespace Nanonets \
  --clientClassName NanonetsClient \
  --targetFramework net10.0 \
  --output Generated \
  --exclude-deprecated-operations
