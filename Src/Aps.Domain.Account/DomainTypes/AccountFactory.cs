namespace Aps.Domain.Account.Tests.DomainTypes
{
    public class AccountFactory
    {
        public Account CreateAccount(ICustomerId customerId, AccountId accountId, Credentials credentials)
        {
            return new Account(customerId, accountId, credentials);
        }
    }
}