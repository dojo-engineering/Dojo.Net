using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Dojo.Net.Tests
{
    public class WebhookClientTests
    {
        private const string SandboxKey = "sk_sandbox_c8oLGaI__msxsXbpBDpdtwJEz_eIhfQoKHmedqgZPCdBx59zpKZLSk8OPLT0cZolbeuYJSBvzDVVsYvtpo5RkQ";

        [Fact]
        public async Task GetAllWebhooksAsync_WhenCalled_ExpectSomeEventsReturned()
        {
            var uri = new Uri($"https://test-no-such-url-{Guid.NewGuid()}.com");

            var client = new WebhooksClient(
                new HttpClient(),
                new ApiKeyClientAuthorization(SandboxKey));

            var allEvents = await client.GetAllWebhooksAsync();

            Assert.True(allEvents.First().Events.Count > 0);
        }
    }
}
