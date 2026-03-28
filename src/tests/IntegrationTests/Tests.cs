namespace Nanonets.IntegrationTests;

[TestClass]
public partial class Tests
{
    private static NanonetsClient GetAuthenticatedClient()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("NANONETS_API_KEY") is { Length: > 0 } apiKeyValue
                ? apiKeyValue
                : throw new AssertInconclusiveException("NANONETS_API_KEY environment variable is not found.");

        var client = new NanonetsClient(
            username: apiKey,
            password: string.Empty);
        
        return client;
    }
}
