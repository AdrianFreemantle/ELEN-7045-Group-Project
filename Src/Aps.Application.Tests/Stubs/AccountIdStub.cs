using Aps.Domain;
using Aps.Domain.Companies;

namespace Aps.Application.Tests.Stubs
{
    public struct AccountIdStub : IAccountId
    {
        public AccountIdStub(string accountId) : this()
        {
            AccountId = accountId;
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