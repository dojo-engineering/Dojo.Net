using System.Text;
using System;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using System.Net.Http;

namespace Dojo.Net
{
    public class BaseClient
    {
        private const string VersionHeaderName = "version";
        private readonly IClientAuthorization _clientAuthorization;
        protected readonly HttpClient _client;

        public BaseClient(HttpClient client, IClientAuthorization clientAuthorization)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _clientAuthorization = clientAuthorization ?? throw new ArgumentNullException(nameof(clientAuthorization));
        }

        protected Task<HttpClient> CreateHttpClientAsync(CancellationToken token)
        {
            return Task.FromResult(_client);
        }

        protected async Task PrepareRequestAsync(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder)
        {
            request.Headers.Add(VersionHeaderName, ApiVersion.Current);
            await _clientAuthorization.AuthorizeRequestAsync(client, request);
        }

        protected Task ProcessResponseAsync(HttpClient client, HttpResponseMessage response, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
