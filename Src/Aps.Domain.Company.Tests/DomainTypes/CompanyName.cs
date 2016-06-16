using System;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public struct CompanyName : IEquatable<CompanyName>
    {
        public string Name { get; private set; }

        public CompanyName(string name) : this()
        {
            this.Name = name;
        }

        public bool Equals(CompanyName other)
        {
            return Name.Equals(other.Name);
        }
    }
}
