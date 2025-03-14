using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Dojo.Net.Tests
{
    public class PaymentIntentsClientTests
    {
        private const string SandboxKey = "sk_sandbox_c8oLGaI__msxsXbpBDpdtwJEz_eIhfQoKHmedqgZPCdBx59zpKZLSk8OPLT0cZolbeuYJSBvzDVVsYvtpo5RkQ";

        [Fact]
        public async Task CreatePaymentIntentAsync_SunshinePayment_ExpectCreated()
        {
            var client = new PaymentIntentsClient(
                new HttpClient(),
                new ApiKeyClientAuthorization(SandboxKey));

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
            var client = new PaymentIntentsClient(
                new HttpClient(),
                new ApiKeyClientAuthorization(SandboxKey));

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
                AutoExpireIn = System.TimeSpan.FromMinutes(5).ToString()
            });

            Assert.Equal(PaymentIntentStatus.Created, pi.Status);
            Assert.Equal(100, pi.Amount.Value);
        }

        [Fact]
        public async Task CreatePaymentIntentAsync_SunshinePaymentWithConfig_ExpectCreated()
        {
            var client = new PaymentIntentsClient(
                new HttpClient(),
                new ApiKeyClientAuthorization(SandboxKey));

            var pi = await client.CreatePaymentIntentAsync(new CreatePaymentIntentRequest
            {
                Amount = new Money
                {
                    Value = 100,
                    CurrencyCode = "GBP"
                },
                Reference = "test",
                Config = new PaymentIntentConfigRequest
                {
                    Title = "Custom Title"
                }
            });

            Assert.Equal(PaymentIntentStatus.Created, pi.Status);
            Assert.Equal(100, pi.Amount.Value);
            Assert.Equal("Custom Title", pi.Config.Title);
        }

        [Fact]
        public async Task CreatePaymentIntentAsync_Retrieve_ExpectRetrieved()
        {
            var client = new PaymentIntentsClient(
                new HttpClient(),
                new ApiKeyClientAuthorization(SandboxKey));

            var pi = await client.CreatePaymentIntentAsync(new CreatePaymentIntentRequest
            {
                Amount = new Money
                {
                    Value = 100,
                    CurrencyCode = "GBP"
                },
                Reference = "test",
            });


            var retrievedPi = await client.GetAsync(pi.Id);

            Assert.Equal(PaymentIntentStatus.Created, retrievedPi.Status);
            Assert.Equal(100, retrievedPi.Amount.Value);
        }
    }
}