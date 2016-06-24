using Aps.Domain.Credential;
using Aps.Domain.Customers;

namespace Aps.Domain.Account.Tests.DomainTypes
{
    public class myScraper
    {
        public myScraper()
        {
            
        }

        public bool ValidateAccount(CustomerId customerId, Account account, Credentials credentials)
        {
            AccountId accountid = account.GetAccountId();

            if (accountid.GetAccountNumber().ToString() == new AccountNumber("XYZ").ToString())
            {
                return false;
            }
            return true;
        }
    }
}
