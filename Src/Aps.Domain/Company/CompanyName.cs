﻿using System;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public struct CompanyName : IEquatable<CompanyName>
    {
        private readonly string companyName;

        public CompanyName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Cannot create a company without a name");
            companyName = name;
        }

        public bool Equals(CompanyName other)
        {
            return companyName.Equals(other.ToString());
        }

        public override string ToString()
        {
            return companyName;
        }
    }
}