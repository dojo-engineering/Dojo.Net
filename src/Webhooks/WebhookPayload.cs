using System;

namespace Dojo.Net
{
    // https://docs.dojo.tech/docs/development-resources/webhooks#payment-intents-webhooks
    public class WebhookPayload
    {
        public class WebhookPayloadData
        {
            public string PaymentIntentId { get; set; }
            public PaymentIntentStatus PaymentStatus { get; set; }
        }

        public string Id { get; set; }
        public string Event { get; set; }
        public string AcocuntId { get; set; }
        public DateTime CreatedAt { get; set; }
        public WebhookPayloadData Data { get; set; }
    }
}
