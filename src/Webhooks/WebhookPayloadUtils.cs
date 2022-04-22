using System;
using System.Security.Cryptography;
using System.Text;

namespace Dojo.Net.Webhooks
{
    /// <summary>
    /// Helper class to read and validate webhook payload
    /// </summary>
    public static class WebhookPayloadUtils
    {
        /// <summary>
        /// Signature header name
        /// </summary>
        public const string SignatureHeaderName = "Dojo-Signature";

        /// <summary>
        /// Reads and validates webhook payload from the request.
        /// </summary>
        /// <param name="requestBody">The request body string.</param>
        /// <param name="webhookSecret">The webhook secret.</param>
        /// <param name="signatureHeader">The signature header.</param>
        /// <returns></returns>
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
