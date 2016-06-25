using System.Collections.Generic;

namespace Aps.Domain.Account
{
    public interface IAccountRepository
    {
        bool SaveAccount(Account newaccount);
        Account FetchById(IAccountId accountId);
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
        //public bool RemoveAccount(ICustomerId customerId, AccountId accountId)
        //{
        //    if (!repo.Contains(accountToBeRemoved))
        //    {
        //        throw new DomainException("Account Repository", "Account does not exist.");
        //    }
        //    repo.Remove(accountToBeRemoved);
        //}
        //public Account GetAccount(ICustomerId customerId, AccountId accountId)
        //{
        //    if (!repo.Contains(accountToBeRemoved))
        //    {
        //        throw new DomainException("Account Repository", "Account does not exist.");
        //    }
        //    repo.Remove(accountToBeRemoved);
        //}


    }
}