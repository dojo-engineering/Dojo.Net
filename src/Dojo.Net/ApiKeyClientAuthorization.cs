using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Dojo.Net
{
    /// <summary>
    /// ApiKey based implementation of the <c>IClientAuthorization</c> interface.
    /// </summary>
    public class ApiKeyClientAuthorization : IClientAuthorization
    {
        private readonly string _apiKey;

        /// <summary>
        /// Initializes a new instance of the <c>ApiKeyClientAuthorization</c> class.
        /// </summary>
        /// <param name="apiKey">The api key</param>
        public ApiKeyClientAuthorization(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        Task IClientAuthorization.AuthorizeRequestsAsync(HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Basic", _apiKey);
            return Task.CompletedTask;
        }
    }
}
