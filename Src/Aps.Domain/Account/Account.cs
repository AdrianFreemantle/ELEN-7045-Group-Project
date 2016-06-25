using System;
using Aps.Domain.Customers;

namespace Aps.Domain.Account
{
    public class Account : IEquatable<Account>
    {
        private readonly CustomerId customerId;
        private readonly AccountId accountId;
        private readonly Credentials credentials;
        private readonly DateTime dateAdded;
        private readonly AccountStatus accountStatus;

        protected Account()
        {            
        }

        internal Account(CustomerId customerId, AccountId accountId, Credentials credentials)
        {
            this.customerId = customerId;
            this.accountId = accountId;
            this.credentials = credentials;
            dateAdded = DateTime.Now;
            this.accountStatus = new AccountStatus(AccountStatus.AccountStatusType.Register);
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
    }
}