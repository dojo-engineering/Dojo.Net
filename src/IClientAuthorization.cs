using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Dojo.Net
{
    public interface IClientAuthorization
    {
        Task AuthorizeRequestAsync(HttpClient client, HttpRequestMessage httpRequestMessage);
    }
}