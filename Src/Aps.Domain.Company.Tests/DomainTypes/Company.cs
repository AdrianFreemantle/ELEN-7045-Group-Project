namespace Aps.Domain.Company.Tests.DomainTypes
{
    public class Company : ICompany
    {
        private readonly CompanyName _companyName;

        internal Company()
        {
        }

        public Company(CompanyName companyName)
        {
            _companyName = companyName;
        }
    }

    internal interface ICompany
    {
    }
}
