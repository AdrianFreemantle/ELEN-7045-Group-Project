namespace Aps.Domain.AccountStatements.Tests.Stubs
{
    public struct AccountIdStub : IAccountId
    {
        private readonly string accountId;

        public AccountIdStub(string accountId)
        {
            this.accountId = accountId;
            AccountNumber = null;
            CompanyName = null;

        }

        public override string ToString()
        {
            return accountId;
        }

        public IAccountNumber AccountNumber { get; }
        public ICompanyName CompanyName { get; }
    }
}