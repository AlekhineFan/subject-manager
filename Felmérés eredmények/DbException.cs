using System;

namespace Felmérés_eredmények
{
    public class DbException : Exception
    {
        public DbException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
