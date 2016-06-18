namespace Aps.Domain.AccountStatements.Tests.Stubs
{
    public struct AccountIdStub : IAccountId
    {

        public AccountIdStub(string accountId, ICompanyName companyName) : this()
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
        public ICompanyName CompanyName { get; set; }
    }
}