using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Dojo.Net.Tests
{
    public class CustomerClientTests
    {
        private const string SandboxKey = "sk_sandbox_c8oLGaI__msxsXbpBDpdtwJEz_eIhfQoKHmedqgZPCdBx59zpKZLSk8OPLT0cZolbeuYJSBvzDVVsYvtpo5RkQ";

        private CustomersClient SystemUnderTest { get; set; }

        public CustomerClientTests()
        {
            SystemUnderTest = new CustomersClient(
                new HttpClient(),
                new ApiKeyClientAuthorization(SandboxKey));
        }

        [Fact]
        public async Task CreateAndDeleteCustomer_GivenValidRequest_ExpectCreated()
        {
            var createCustomerRequest = new CreateCustomerRequest
            {
                EmailAddress = "dojo.net.sdk@dojo.dev",
                Name = "Dojo.NET"
            };

            var customer = await SystemUnderTest.CreateAsync(createCustomerRequest);

            Assert.NotNull(customer);

            await SystemUnderTest.DeleteAsync(customer.Id);

            var existingCustomer = await SystemUnderTest.GetAsync(customer.Id);

            Assert.Empty(existingCustomer);
        }

        [Fact]
        public async Task GetPaymentMethods_GivenValidRequest_ExpectPaymentMethods()
        {
            var createCustomerRequest = new CreateCustomerRequest
            {
                EmailAddress = "dojo.net.sdk@dojo.dev",
                Name = "Dojo.NET"
            };
            CustomerPaymentMethods customerPaymentMethods = null;


            var customer = await SystemUnderTest.CreateAsync(createCustomerRequest);

            try
            {
                var customerSecret = await SystemUnderTest.CreateCustomerSecretAsync(customer.Id);
                customerPaymentMethods = await SystemUnderTest.GetPaymentMethodsAsync(customer.Id, "Basic " + customerSecret.Secret);
            }
            catch (Exception e)
            {
                await SystemUnderTest.DeleteAsync(customer.Id);
            }

            Assert.NotNull(customerPaymentMethods);
        }
    }
}
