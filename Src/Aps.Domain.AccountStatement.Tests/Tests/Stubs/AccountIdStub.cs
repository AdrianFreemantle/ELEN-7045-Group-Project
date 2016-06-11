namespace Aps.Domain.AccountStatement.Tests.Tests.Stubs
{
    public struct AccountIdStub : IAccountId
    {
        private readonly string accountId;

        public AccountIdStub(string accountId)
        {
            this.accountId = accountId;
        }

        public override string ToString()
        {
            return accountId;
        }
    }
}