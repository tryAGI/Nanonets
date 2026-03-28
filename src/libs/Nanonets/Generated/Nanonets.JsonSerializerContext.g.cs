
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant

namespace Nanonets
{
    /// <summary>
    /// 
    /// </summary>
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[]
        {
            typeof(global::Nanonets.JsonConverters.UnixTimestampJsonConverter),
        })]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Nanonets.JsonSerializerContextTypes))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(string))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(byte[]))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Nanonets.OcrUploadUrlRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Nanonets.OcrUploadFileRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Nanonets.OcrPredictUrlRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Nanonets.OcrPredictUrlAsyncRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Nanonets.OcrPredictFileRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Nanonets.OcrPredictFileAsyncRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Nanonets.IcUploadUrlRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Nanonets.IcUploadFileRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Nanonets.IcPredictUrlRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Nanonets.IcPredictFileRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(object))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}