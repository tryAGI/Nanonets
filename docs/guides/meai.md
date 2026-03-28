# Microsoft.Extensions.AI Integration

The Nanonets SDK provides `AIFunction` tools that integrate with any `IChatClient` via [Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI).

## Available Tools

| Tool | Method | Description |
|------|--------|-------------|
| `OcrExtract` | `AsOcrTool(modelId)` | Extract text and structured data from images/documents using OCR |
| `ClassifyImage` | `AsClassifyTool(modelId)` | Classify images into categories using a trained model |
| `GetModelDetails` | `AsGetModelDetailsTool(modelId)` | Retrieve details about a trained OCR model |

## Usage

```csharp
using Nanonets;
using Microsoft.Extensions.AI;

// Create the Nanonets client (API key as username, empty password)
using var nanonetsClient = new NanonetsClient(
    username: Environment.GetEnvironmentVariable("NANONETS_API_KEY")!,
    password: string.Empty);

// Create tools
var ocrTool = nanonetsClient.AsOcrTool(modelId: "your-model-id");
var classifyTool = nanonetsClient.AsClassifyTool(modelId: "your-model-id");

// Use with any IChatClient
IChatClient chatClient = /* your preferred chat client */;
var response = await chatClient.GetResponseAsync(
    "Extract the text from this invoice: https://example.com/invoice.png",
    new ChatOptions
    {
        Tools = [ocrTool],
    });
```

## Notes

- Models must be created and trained on the [Nanonets web app](https://app.nanonets.com) before use
- OCR supports PNG, JPEG, and PDF formats
- Image classification supports PNG and JPEG formats
- Multiple image URLs can be passed in a single request
