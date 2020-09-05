using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Exceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message, Exception ex) : base(message, ex)
        {
            
        }
    }
}
