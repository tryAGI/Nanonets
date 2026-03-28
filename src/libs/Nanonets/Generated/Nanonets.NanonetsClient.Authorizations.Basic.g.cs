
#nullable enable

namespace Nanonets
{
    public sealed partial class NanonetsClient
    {
        /// <inheritdoc/>
        public void AuthorizeUsingBasic(
            string username,
            string password)
        {
            username = username ?? throw new global::System.ArgumentNullException(nameof(username));
            password = password ?? throw new global::System.ArgumentNullException(nameof(password));

            Authorizations.Clear();
            Authorizations.Add(new global::Nanonets.EndPointAuthorization
            {
                Type = "Http",
                Location = "Header",
                Name = "Basic",
                Value = global::System.Convert.ToBase64String(
                    global::System.Text.Encoding.UTF8.GetBytes($"{username}:{password}")),
            });
        }
    }
}