namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    class AccountIdStub : IAccountId
    {
        public IAccountNumber AccountNumber { get; set; }
        public ICompanyName CompanyName { get; set; }
    }
}