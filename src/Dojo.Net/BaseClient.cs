using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dojo.Net
{
    /// <summary>
    /// Base client class.
    /// </summary>
    public class BaseClient
    {
        private const string VersionHeaderName = "version";

        /// <summary>
        /// HttpClient instance
        /// </summary>
        protected readonly HttpClient Client;

        /// <summary>
        /// Initializes a new instance of the <c>BaseClient</c> class.
        /// </summary>
        /// <param name="client">HttpClient instance</param>
        /// <param name="clientAuthorization">The IClientAuthorization instance</param>
        public BaseClient(HttpClient client, IClientAuthorization clientAuthorization)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            _ = clientAuthorization ?? throw new ArgumentNullException(nameof(clientAuthorization));
            clientAuthorization.AuthorizeRequestsAsync(client);
            Client.DefaultRequestHeaders.Add(VersionHeaderName, ApiVersion.Current);
        }

        /// <summary>
        /// Creates an instance of HttpClient
        /// </summary>
        /// <param name="token">The cancellation token</param>
        protected Task<HttpClient> CreateHttpClientAsync(CancellationToken token)
        {
            return Task.FromResult(Client);
        }

        /// <summary>
        /// Prepares request
        /// </summary>
        /// <param name="client">The HttpClient instance</param>
        /// <param name="request">Http request message</param>
        /// <param name="urlBuilder">Url string builder</param>
        protected Task PrepareRequestAsync(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Process response
        /// </summary>
        /// <param name="client">The HttpClient instance</param>
        /// <param name="response">Http reponse</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected Task ProcessResponseAsync(HttpClient client, HttpResponseMessage response, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
