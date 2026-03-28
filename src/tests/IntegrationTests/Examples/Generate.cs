/*
order: 10
title: OCR Prediction
slug: ocr-prediction

Basic example showing how to create a client and run OCR prediction on an image URL.
*/

namespace Nanonets.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_OcrPrediction()
    {
        using var client = GetAuthenticatedClient();

        //// Create a Nanonets client and predict using an OCR model.
        //// The model must be created and trained on the Nanonets web app first.
        var modelId =
            Environment.GetEnvironmentVariable("NANONETS_MODEL_ID") is { Length: > 0 } modelValue
                ? modelValue
                : throw new AssertInconclusiveException("NANONETS_MODEL_ID environment variable is not found.");

        var result = await client.OcrPredict.OcrPredictUrlAsync(
            modelId: modelId,
            urls: "https://nanonets.s3-us-west-2.amazonaws.com/test-images/test1.jpg");
    }
}
