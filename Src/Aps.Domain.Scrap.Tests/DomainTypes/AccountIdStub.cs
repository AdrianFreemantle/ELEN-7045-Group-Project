namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    class AccountIdStub : IAccountId
    {
        public IAccountNumber AccountNumber { get; }
        public ICompanyName CompanyName { get; }
    }
}