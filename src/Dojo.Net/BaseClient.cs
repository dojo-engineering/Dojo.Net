using System.Text;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace Dojo.Net
{
    /// <summary>
    /// Base client class.
    /// </summary>
    public class BaseClient
    {
        private const string VersionHeaderName = "version";
        private readonly IClientAuthorization _clientAuthorization;

        /// <summary>
        /// HttpClient instance
        /// </summary>
        protected readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <c>BaseClient</c> class.
        /// </summary>
        /// <param name="client">HttpClient instance</param>
        /// <param name="clientAuthorization">The IClientAuthorization instance</param>
        public BaseClient(HttpClient client, IClientAuthorization clientAuthorization)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _clientAuthorization = clientAuthorization ?? throw new ArgumentNullException(nameof(clientAuthorization));
        }

        /// <summary>
        /// Creates an instance of HttpClient
        /// </summary>
        /// <param name="token">The cancellation token</param>
        protected Task<HttpClient> CreateHttpClientAsync(CancellationToken token)
        {
            return Task.FromResult(_client);
        }

        /// <summary>
        /// Prepares request
        /// </summary>
        /// <param name="client">The HttpClient instance</param>
        /// <param name="request">Http request message</param>
        /// <param name="urlBuilder">Url string builder</param>
        protected async Task PrepareRequestAsync(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder)
        {
            request.Headers.Add(VersionHeaderName, ApiVersion.Current);
            await _clientAuthorization.AuthorizeRequestAsync(client, request);
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
