using System;
using System.Runtime.Serialization;

namespace App.Src.Shared.Application.Errors
{
    [Serializable]
    public class AppException : Exception
    {
        public int? StatusCode { get; set; }

        public AppException(string message)
            : base(message)
        {
        }
        public AppException(string message, int? statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        // Without this constructor, deserialization will fail
        protected AppException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
