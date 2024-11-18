using System;
namespace TakoTea.Exceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException()
            : base("An error occurred while accessing the database.")
        {
        }
        public DataAccessException(string message)
            : base(message)
        {
        }
        public DataAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public DataAccessException(string message, int errorCode)
            : base($"{message} Error Code: {errorCode}")
        {
        }
    }
}
