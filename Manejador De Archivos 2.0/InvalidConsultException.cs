using System;
using System.Runtime.Serialization;

namespace Manejador_De_Archivos_2._0
{
    [Serializable]
    internal class InvalidConsultException : Exception
    {
        public InvalidConsultException()
        {
        }

        public InvalidConsultException(string message) : base(message)
        {
        }

        public InvalidConsultException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidConsultException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}