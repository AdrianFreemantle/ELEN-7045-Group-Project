using System;

namespace Aps.Domain.AccountStatements
{
    public class DataIntegrityCheckFailedException : Exception
    {
        public DataIntegrityCheckFailedException()
        {
        }

        public DataIntegrityCheckFailedException(string message) : base(message)
        {
        }

        public DataIntegrityCheckFailedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}