
#nullable enable

namespace Nanonets
{
    public sealed partial class NanonetsClient
    {
        /// <inheritdoc cref="NanonetsClient(global::System.Net.Http.HttpClient?, global::System.Uri?, global::System.Collections.Generic.List{global::Nanonets.EndPointAuthorization}?, bool)"/>

        public NanonetsClient(
            string username,
            string password,
            global::System.Net.Http.HttpClient? httpClient = null,
            global::System.Uri? baseUri = null,
            global::System.Collections.Generic.List<global::Nanonets.EndPointAuthorization>? authorizations = null,
            bool disposeHttpClient = true) : this(httpClient, baseUri, authorizations, disposeHttpClient)
        {
            Authorizing(HttpClient, ref username, ref password);

            AuthorizeUsingBasic(username, password);

            Authorized(HttpClient);
        }

        partial void Authorizing(
            global::System.Net.Http.HttpClient client,
            ref string username,
            ref string password);
        partial void Authorized(
            global::System.Net.Http.HttpClient client);
    }
}