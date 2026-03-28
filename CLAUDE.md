# CLAUDE.md — Nanonets SDK

## Overview

Auto-generated C# SDK for [Nanonets](https://nanonets.com) — an intelligent document processing and OCR platform supporting 110+ languages.

## Build Commands

```bash
# Build the solution
dotnet build Nanonets.slnx

# Build for release (also produces NuGet package)
dotnet build Nanonets.slnx -c Release

# Run integration tests (requires NANONETS_API_KEY env var)
dotnet test src/tests/IntegrationTests/Nanonets.IntegrationTests.csproj

# Regenerate SDK from OpenAPI spec
cd src/libs/Nanonets && ./generate.sh
```

## Architecture

### Code Generation Pipeline

The SDK code is **entirely auto-generated** — do not manually edit files in `src/libs/Nanonets/Generated/`.

1. `src/libs/Nanonets/openapi.yaml` — the Nanonets OpenAPI spec
2. `src/libs/Nanonets/generate.sh` — orchestrates: download spec, run AutoSDK CLI, output to `Generated/`
3. CI auto-updates the spec and creates PRs if changes are detected

### Project Layout

| Project | Purpose |
|---------|---------|
| `src/libs/Nanonets/` | Main SDK library (`NanonetsClient`) |
| `src/libs/Nanonets/Extensions/` | Hand-written MEAI `AIFunction` tools |
| `src/tests/IntegrationTests/` | Integration tests against real Nanonets API |

### Auth

Nanonets uses **HTTP Basic Auth** (API key as username, empty password):

```csharp
var client = new NanonetsClient(
    username: apiKey,    // NANONETS_API_KEY
    password: string.Empty);
```

### Sub-Clients

The client exposes typed sub-clients for each API category:
- `client.OcrModelDetails` — Get OCR model details
- `client.OcrUpload` — Upload OCR training images
- `client.OcrTrain` — Train OCR models
- `client.OcrPredict` — OCR prediction (file, URL, async)
- `client.IcModelDetails` — Get Image Classification model details
- `client.IcUpload` — Upload IC training images
- `client.IcTrain` — Train IC models
- `client.IcPredict` — IC prediction (file, URL)

### MEAI Integration

AIFunction tools for use with any `IChatClient`:
- `AsOcrTool(modelId)` — Extract text/data from image URLs via OCR
- `AsClassifyTool(modelId)` — Classify images via trained IC model
- `AsGetModelDetailsTool(modelId)` — Retrieve model details

### Documentation Generation

Tests in `src/tests/IntegrationTests/Examples` are the single source of truth for both test coverage and documentation:
- Each file has a JSDoc header (`order`, `title`, `slug`) consumed by `autosdk docs sync .`
- Comments prefixed with `////` become prose paragraphs in generated docs
- CI workflow (`.github/workflows/mkdocs.yml`) auto-generates `docs/examples/` and populates `EXAMPLES:START/END` markers

### Build Configuration

- **Target:** `net10.0` (single target)
- **Language:** C# preview with nullable reference types
- **Signing:** Strong-named assemblies via `src/key.snk`
- **Versioning:** Semantic versioning from git tags (`v` prefix) via MinVer
- **Analysis:** All .NET analyzers enabled, AOT/trimming compatibility enforced
- **Testing:** MSTest + AwesomeAssertions
