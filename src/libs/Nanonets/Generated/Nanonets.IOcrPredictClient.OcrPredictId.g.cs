#nullable enable

namespace Nanonets
{
    public partial interface IOcrPredictClient
    {
        /// <summary>
        /// Get Prediction File by ID<br/>
        /// Retrieve the prediction results of a particular file by its ID.
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Nanonets.ApiException"></exception>
        /// <remarks>
        /// var client = new RestClient("https://app.nanonets.com/api/v2/Inferences/Model/{{model_id}}/ImageLevelInferences/{{id}}");<br/>
        /// var request = new RestRequest(Method.GET);<br/>
        /// request.AddHeader("authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("[[.ApiKey]]:")));<br/>
        /// IRestResponse response = client.Execute(request);
        /// </remarks>
        global::System.Threading.Tasks.Task<string> OcrPredictIdAsync(
            string modelId,
            string id,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}