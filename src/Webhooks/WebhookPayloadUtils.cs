using System;
using System.Security.Cryptography;
using System.Text;

namespace Dojo.Net.Webhooks
{
    public static class WebhookPayloadUtils
    {
        public const string SignatureHeaderName = "Dojo-Signature";

        public static WebhookPayload ReadPayload(string requestBody, string webhookSecret, string signatureHeader)
        {
            if(string.IsNullOrEmpty(requestBody))
            {
                throw new ArgumentNullException(nameof(requestBody));
            }

            if(string.IsNullOrEmpty(webhookSecret))
            {
                throw new ArgumentNullException(nameof(webhookSecret));
            }

            if(string.IsNullOrEmpty(signatureHeader))
            {
                throw new ArgumentNullException(nameof(signatureHeader));
            }

            var receivedSignature = signatureHeader.Split("=");

            if (receivedSignature.Length != 2)
            {
                throw new WebhookSignatureException("Invalid payload signature");
            }

            string computedSignature;
            switch (receivedSignature[0])
            {
                case "sha256":
                    var secretBytes = Encoding.UTF8.GetBytes(webhookSecret);
                    using (var hasher = new HMACSHA256(secretBytes))
                    {
                        var data = Encoding.UTF8.GetBytes(requestBody);
                        computedSignature = BitConverter.ToString(hasher.ComputeHash(data));
                    }
                    break;
                default:
                    throw new WebhookSignatureException("Invalid payload signature");
            }

            if (computedSignature != receivedSignature[1])
            {
                throw new WebhookSignatureException("Invalid payload signature");
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<WebhookPayload>(requestBody, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
