using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Dojo.Net.Tests
{
    public class PaymentIntentsClientTests
    {
        [Fact]
        public async Task CreatePaymentIntentAsync_SunshinePayment_ExpectCreated()
        {
            var apiKey = "sk_sandbox_c8oLGaI__msxsXbpBDpdtwJEz_eIhfQoKHmedqgZPCdBx59zpKZLSk8OPLT0cZolbeuYJSBvzDVVsYvtpo5RkQ";

            var client = new PaymentIntentsClient(
                new HttpClient(),
                new ApiKeyClientAuthorization(apiKey));

            var pi = await client.CreatePaymentIntentAsync(new CreatePaymentIntentRequest
            {
                Amount = new Money
                {
                    Value = 100,
                    CurrencyCode = "GBP"
                },  
                Reference = "test",
            });

            Assert.Equal(PaymentIntentStatus.Created, pi.Status);
            Assert.Equal(100, pi.Amount.Value);
        }

        [Fact]
        public async Task CreatePaymentIntentAsync_CreatePreAuth_ExpectCreated()
        {
            var apiKey = "sk_sandbox_c8oLGaI__msxsXbpBDpdtwJEz_eIhfQoKHmedqgZPCdBx59zpKZLSk8OPLT0cZolbeuYJSBvzDVVsYvtpo5RkQ";

            var client = new PaymentIntentsClient(
                new HttpClient(),
                new ApiKeyClientAuthorization(apiKey));

            var pi = await client.CreatePaymentIntentAsync(new CreatePaymentIntentRequest
            {
                Amount = new Money
                {
                    Value = 100,
                    CurrencyCode = "GBP"
                },
                Reference = "test",
                CaptureMode = CaptureMode.Manual,
                AutoExpireAction = AutoExpireAction.Release,
                AutoExpireAt = System.DateTime.UtcNow.AddMinutes(5)
            });

            Assert.Equal(PaymentIntentStatus.Created, pi.Status);
            Assert.Equal(100, pi.Amount.Value);
        }
    }
}