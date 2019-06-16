using System;
using System.Runtime.Serialization;

namespace EstacionMeteorologica.Api
{
    [Serializable]
    internal class WeatherUnKnnowException : Exception
    {
        public WeatherUnKnnowException()
        {

        }

        public WeatherUnKnnowException(string message) : base(message)
        {
        }

        public WeatherUnKnnowException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WeatherUnKnnowException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}