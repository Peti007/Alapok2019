using System;
using System.Runtime.Serialization;

namespace _02Exeptions
{
    [Serializable]
    public class AcountException : ApplicationException
    {
        public AcountException()
        {
        }

        public AcountException(string message) : base(message)
        {
        }

        public AcountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AcountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}