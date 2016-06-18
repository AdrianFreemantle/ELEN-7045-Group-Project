using Aps.Domain.Company.Tests.DomainTypes;

namespace Aps.Domain.AccountStatements.Tests.Stubs
{
    public struct AccountIdStub : IAccountId
    {

        public AccountIdStub(string accountId, CompanyName companyName) : this()
        {
            AccountId = accountId;
            AccountNumber = null;
            CompanyName = companyName;

        }

        public override string ToString()
        {
            return AccountId;
        }

        public string AccountId { get; set; }
        public IAccountNumber AccountNumber { get; set; }
        public CompanyName CompanyName { get; set; }
    }
}