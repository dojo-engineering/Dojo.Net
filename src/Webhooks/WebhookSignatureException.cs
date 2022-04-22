using System;
using System.Runtime.Serialization;

namespace Dojo.Net.Webhooks
{
    public class WebhookSignatureException: Exception
    {
        public WebhookSignatureException(): base()
        {
        }

        protected WebhookSignatureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public WebhookSignatureException(string message) : base(message)
        {
        }

        public WebhookSignatureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
