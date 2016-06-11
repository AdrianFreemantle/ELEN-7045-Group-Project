using System;
using Aps.Domain.Account;

namespace Aps.Domain.Account.Tests.Tests.DomainTypes
{
    public struct AccountId
    {
        private readonly AccountNumber accountNumber;
        private readonly ICompanyName companyName;

        private AccountId(ICompanyName companyName, AccountNumber accountNumber)
        {
            this.companyName = companyName;
            this.accountNumber = accountNumber;
        }

        public static AccountId Create<TCompanyName>(TCompanyName companyName, AccountNumber accountNumber) where TCompanyName : struct, ICompanyName
        {
            Guard.ThatValueTypeNotDefaut(companyName, "companyName");
            Guard.ThatValueTypeNotDefaut(accountNumber, "accountNumber");

            return new AccountId(companyName, accountNumber);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", companyName, accountNumber);
        }
    }
}