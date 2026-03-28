#pragma warning disable CS3002 // Return type is not CLS-compliant
using Microsoft.Extensions.AI;

namespace Nanonets;

/// <summary>
/// Extensions for using NanonetsClient as MEAI tools with any IChatClient.
/// </summary>
public static class NanonetsToolExtensions
{
    /// <summary>
    /// Creates an <see cref="AIFunction"/> that performs OCR on image URLs,
    /// extracting text and structured data using a trained Nanonets model.
    /// </summary>
    /// <param name="client">The Nanonets client to use.</param>
    /// <param name="modelId">The ID of the trained OCR model to use for extraction.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    public static AIFunction AsOcrTool(
        this NanonetsClient client,
        string modelId)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentException.ThrowIfNullOrWhiteSpace(modelId);

        return AIFunctionFactory.Create(
            async (string urls, CancellationToken cancellationToken) =>
            {
                var response = await client.OcrPredict.OcrPredictUrlAsync(
                    modelId: modelId,
                    urls: urls,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return response;
            },
            name: "OcrExtract",
            description: "Extracts text and structured data from images or documents using OCR (Optical Character Recognition). Pass one or more image URLs to extract text content.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that classifies images using
    /// a trained Nanonets image classification model.
    /// </summary>
    /// <param name="client">The Nanonets client to use.</param>
    /// <param name="modelId">The ID of the trained image classification model.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    public static AIFunction AsClassifyTool(
        this NanonetsClient client,
        string modelId)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentException.ThrowIfNullOrWhiteSpace(modelId);

        return AIFunctionFactory.Create(
            async (string urls, CancellationToken cancellationToken) =>
            {
                var response = await client.IcPredict.IcPredictUrlAsync(
                    modelId: modelId,
                    urls: urls,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return response;
            },
            name: "ClassifyImage",
            description: "Classifies images into categories using a trained image classification model. Pass one or more image URLs to get classification results.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that retrieves details about
    /// a Nanonets OCR model, including its labels, training status, and configuration.
    /// </summary>
    /// <param name="client">The Nanonets client to use.</param>
    /// <param name="modelId">The ID of the OCR model to retrieve details for.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    public static AIFunction AsGetModelDetailsTool(
        this NanonetsClient client,
        string modelId)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentException.ThrowIfNullOrWhiteSpace(modelId);

        return AIFunctionFactory.Create(
            async (CancellationToken cancellationToken) =>
            {
                var response = await client.OcrModelDetails.OcrModelIdAsync(
                    modelId: modelId,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return response;
            },
            name: "GetModelDetails",
            description: "Retrieves details about a Nanonets OCR model, including its labels, training status, and configuration.");
    }
}
