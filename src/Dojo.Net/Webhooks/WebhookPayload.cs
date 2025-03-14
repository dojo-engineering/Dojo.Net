using System;

namespace Dojo.Net
{
    // https://docs.dojo.tech/docs/development-resources/webhooks#payment-intents-webhooks
    /// <summary>
    /// Webhook payload.
    /// </summary>
    public class WebhookPayload
    {
        /// <summary>
        /// Webhook payload data.
        /// </summary>
        public class WebhookPayloadData
        {
            /// <summary>
            /// Payment intent id
            /// </summary>
            public string PaymentIntentId { get; set; }
            /// <summary>
            /// Status of the payment intent.
            /// </summary>
            public PaymentIntentStatus PaymentStatus { get; set; }
        }

        /// <summary>
        /// Webhook message id
        /// </summary>
        /// <value></value>
        public string Id { get; set; }
        /// <summary>
        /// Event type
        /// </summary>
        public string Event { get; set; }
        /// <summary>
        /// Account id
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// The date when the message was created
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Webhook message data
        /// </summary>
        public WebhookPayloadData Data { get; set; }
    }
}
