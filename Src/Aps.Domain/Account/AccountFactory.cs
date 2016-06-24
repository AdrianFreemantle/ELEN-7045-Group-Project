using Aps.Domain.Customers;

namespace Aps.Domain.Account
{
    public class AccountFactory
    {
        public Account CreateAccount(CustomerId customerId, AccountId accountId, Credentials credentials)
        {
            return new Account(customerId, accountId, credentials);
        }
    }
}