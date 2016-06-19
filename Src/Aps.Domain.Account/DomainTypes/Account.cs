using System;
using System.Collections.Generic;

namespace Aps.Domain.Account.Tests.DomainTypes
{
    public struct Account
    {
        private readonly AccountId accountId;
        private readonly ICustomerId customerId;
        private readonly AccountStatus accountStatus;
       

        private Account(ICustomerId customerId, AccountId accountId)
        {
            this.accountId = accountId;
            this.customerId = customerId;
            this.accountStatus = new AccountStatus();
        }

        public static Account Create<TCustomerId>(TCustomerId customerId, AccountId accountId) where TCustomerId : struct, ICustomerId
        {
            Guard.ThatValueTypeNotDefaut(customerId, "CustomerId");
            Guard.ThatValueTypeNotDefaut(accountId, "AccountId");

            return new Account(customerId, accountId);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", accountId, customerId);
        }
    }
}