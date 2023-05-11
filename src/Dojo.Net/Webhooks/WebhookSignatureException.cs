using System;
using System.Runtime.Serialization;

namespace Dojo.Net.Webhooks
{
    /// <summary>
    /// Represents errors that occur during webhook signature verification.
    /// </summary>
    public class WebhookSignatureException: Exception
    {
        /// <summary>
        /// Initializes a new instance of the <c>WebhookSignatureException</c> class.
        /// </summary>
        public WebhookSignatureException(): base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c>WebhookSignatureException</c> class with serialized data.
        /// </summary>
        /// <param name="info">
        /// The System.Runtime.Serialization.SerializationInfo that holds the serialized
        /// object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The System.Runtime.Serialization.StreamingContext that contains contextual information
        /// about the source or destination.
        /// </param>
        protected WebhookSignatureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c>WebhookSignatureException</c> class with a specified error
        /// message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public WebhookSignatureException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c>WebhookSignatureException</c> class with a specified error
        ///     message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        public WebhookSignatureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
