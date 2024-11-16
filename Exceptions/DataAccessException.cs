using System;

namespace TakoTea.Exceptions
{
    public class DataAccessException : Exception
    {
        // Default constructor
        public DataAccessException() { }

        // Constructor that takes a message
        public DataAccessException(string message) : base(message) { }

        // Constructor that takes a message and an inner exception
        public DataAccessException(string message, Exception innerException)
            : base(message, innerException) { }
    }

}
