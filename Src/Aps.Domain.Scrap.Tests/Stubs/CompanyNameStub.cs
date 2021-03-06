namespace Aps.Domain.Scrap.Tests.Stubs
{
    public struct CompanyNameStub : ICompanyName
    {
        private readonly string companyName;

        public CompanyNameStub(string companyName)
        {
            this.companyName = companyName;
        }

        public override string ToString()
        {
            return companyName;
        }

    }
}