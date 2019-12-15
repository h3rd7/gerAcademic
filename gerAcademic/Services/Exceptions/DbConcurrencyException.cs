using System;

namespace gerAcademic.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string message) : base (message)
        {
        }
    }
}
