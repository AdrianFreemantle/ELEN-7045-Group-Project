using System;
using System.Collections.Generic;
using Aps.Domain.Customers;

namespace Aps.Domain.Account
{
    public class Account : IEquatable<Account>
    {
        private readonly CustomerId customerId;
        private readonly AccountId accountId;
        private Credentials credentials;
        private AccountStatus accountStatus;

        protected Account()
        {            
        }

        internal Account(CustomerId customerId, AccountId accountId, Credentials credentials)
        {
            Guard.ThatValueTypeNotDefaut(customerId, "customerId");
            Guard.ThatValueTypeNotDefaut(accountId, "accountId");
            Guard.ThatValueTypeNotDefaut(credentials, "credentials");

            this.customerId = customerId;
            this.accountId = accountId;
            this.credentials = credentials;
            this.accountStatus = new AccountStatus(AccountStatus.AccountStatusType.Register);
        }

        public void Display(IAccountDisplayAdapter displayAdapter)
        {
           displayAdapter.Display(accountId);
        }

        public void UpdateCredentials(Credentials credetnials)
        {
            throw new NotImplementedException();
        }

        public bool Equals(AccountId other)
        {
            return accountId.Equals(other);
        }

        public bool Equals(Account other)
        {
            if (other == null)
                return false;

            return Equals(other.accountId);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", accountId, customerId);
        }

        public CustomerId GetCustomerId()
        {
            return customerId;
        }

        public AccountId GetAccountId()
        {
            return accountId;
        }

        public ICompanyName GetCompanyName()
        {
            return accountId.GetCompanyName();
        }

        public Credentials GetCredentials()
        {
            return credentials;
        }

        public AccountStatus GetAccountStatus()
        {
            return accountStatus;
        }
        public bool SetAccountStatus(AccountStatus accountStatus)
        {
            this.accountStatus = accountStatus; 
            return true;
        }


    }
}