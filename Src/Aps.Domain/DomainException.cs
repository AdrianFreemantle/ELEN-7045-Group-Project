using System;

namespace Aps.Domain
{
    public class DomainException : Exception
    {
        public string Name { get; private set; }

        public DomainException(string name, string message)
            : base(message)
        {
            Name = name;
        }

        public DomainException(string name, string message, Exception inner)
            : base(message, inner)
        {
            Name = name;
        }
    }
}
