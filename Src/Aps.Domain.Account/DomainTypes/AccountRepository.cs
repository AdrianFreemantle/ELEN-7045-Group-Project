using System.Collections.Generic;

namespace Aps.Domain.Account.Tests.DomainTypes
{
    public class AccountRepository
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