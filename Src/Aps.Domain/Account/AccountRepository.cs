using System.Collections.Generic;
using Aps.Domain.Common;
using Aps.Domain.Credential;
using Aps.Domain.Customers;

namespace Aps.Domain.Account
{
    public interface IAccountRepository
    {
        bool SaveAccount(Account newaccount);
        Account GetAccount(AccountId accountId);
        Account FetchById(AccountId accountId);
        int Count();
    }

    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> repo = new List<Account>();

        public bool SaveAccount(Account newaccount)
        {
            if (repo.Contains(newaccount))
            {
                throw new DomainException("Account Repository", "Account already exist.");
            }
            repo.Add(newaccount);
            return true;
        }

        public Account FetchById(IAccountId accountId)
        {
            throw new System.NotImplementedException();
        }

        public Account FetchById(AccountId accountId)
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            return repo.Count;
        }

        public Account GetAccount(AccountId accountId)
        {
            // To-Do Add GetAccount functionality

            if (repo.Count == 0)
                throw new DomainException("Account Repository", "No Accounts stored");



            return repo[0];

            IEncryptionService encryptionService = new Encryption();
            var credentials = Credentials.Create(new EmailAddress("chrisv@live.co.za"), new Password("123", "123", encryptionService));

            return new Account(new CustomerId(new EmailAddress("chrisv@live.co.za")), accountId, credentials);
        }

        //public bool RemoveAccount(ICustomerId customerId, AccountId accountId)
        //{
        //    if (!repo.Contains(accountToBeRemoved))
        //    {
        //        throw new DomainException("Account Repository", "Account does not exist.");
        //    }
        //    repo.Remove(accountToBeRemoved);
        //}


    }
}