using Dojo.Net.Webhooks;
using Xunit;

namespace Dojo.Net.Tests
{
    public class WebhookPayloadUtilsTests
    {
        [Fact]
        public void ReadPayload_FeedExampleFromDocs_ExpectNoException()
        {
            var json = "{\"id\":\"evt_hnnHxIKR_Uy6bhZCusCltw\",\"event\":\"payment_intent.created\",\"accountId\":\"acc_test\",\"createdAt\":\"2022-02-01T13:07:41.8667859Z\",\"data\":{\"paymentIntentId\":\"pi_vpwd4ooAPEqyNAQe4z89WQ\",\"paymentStatus\":\"Created\",\"captureMode\":\"Auto\"}}";
            WebhookPayloadUtils.ReadPayload(json, "PDYkJQq6sESYHp_zJuTTBQ", "sha256=4B-49-F8-FE-25-A7-E6-7D-00-4F-A7-9C-F8-0B-63-00-C7-77-B4-F2-2D-E5-E1-22-84-FA-04-18-50-A1-76-FD");
        }

        [Fact]
        public void ReadPayload_FeedIncorrectExampleFromDocs_ExpectException()
        {
            var json = "{\"id\":\"evt_hnnHxIKR_Uy6bhZCusCltw\",\"event\":\"payment_intent.created\",\"accountId\":\"acc_test\",\"createdAt\":\"2022-02-01T13:07:41.8667859Z\",\"data\":{\"paymentIntentId\":\"pi_vpwd4ooAPEqyNAQe4z89WQ\",\"paymentStatus\":\"Created\",\"captureMode\":\"Auto\"}}";
            WebhookPayloadUtils.ReadPayload(json, "PDYkJQq6sESYHp_zJuTTBQ", "sha256=5B-49-F8-FE-25-A7-E6-7D-00-4F-A7-9C-F8-0B-63-00-C7-77-B4-F2-2D-E5-E1-22-84-FA-04-18-50-A1-76-FD");
        }
    }
}
