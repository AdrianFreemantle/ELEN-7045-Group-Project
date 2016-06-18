using System;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public struct CompanyType : IEquatable<CompanyType>
    {
        private readonly CompanyTypeEnum _companyType;

        private enum CompanyTypeEnum
        {
            Unknown,
            TelcoServiceProvider,
            Municipality,
            CreditCardProvider
        }

        public static CompanyType TelcoServiceProvider
        {
            get { return new CompanyType(CompanyTypeEnum.TelcoServiceProvider);}
        }

        public static CompanyType Municipality
        {
            get { return new CompanyType(CompanyTypeEnum.Municipality); }
        }

        public static CompanyType CreditCardProvider
        {
            get { return new CompanyType(CompanyTypeEnum.CreditCardProvider); }
        }

        private CompanyType(CompanyTypeEnum companyType)
        {
            this._companyType = companyType;
        }

        public bool Equals(CompanyType other)
        {
            return _companyType.Equals(other._companyType);
        }
    }
}
