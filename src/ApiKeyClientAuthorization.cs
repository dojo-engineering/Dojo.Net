using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Dojo.Net
{
    public class ApiKeyClientAuthorization : IClientAuthorization
    {
        private readonly string _apiKey;

        public ApiKeyClientAuthorization(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        Task IClientAuthorization.AuthorizeRequestAsync(HttpClient client, HttpRequestMessage httpRequestMessage)
        {
            httpRequestMessage.Headers.Authorization =  new AuthenticationHeaderValue("Basic", _apiKey);
            return Task.CompletedTask;
        }
    }
}
