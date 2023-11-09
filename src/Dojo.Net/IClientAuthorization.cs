using System.Threading.Tasks;
using System.Net.Http;

namespace Dojo.Net
{
    /// <summary>
    /// Client authorization interface
    /// </summary>
    public interface IClientAuthorization
    {

        /// <summary>
        /// Authorize request
        /// </summary>
        /// <param name="client">The HttpClient instance</param>
        Task AuthorizeRequestsAsync(HttpClient client);
    }
}