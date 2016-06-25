using System;
using Aps.Domain.Credential;

namespace Aps.Domain.Account
{
    public struct AccountId
    {
        private readonly AccountNumber accountNumber;
        private readonly ICompanyName companyName;

        public AccountId(ICompanyName companyName, AccountNumber accountNumber)
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

        public AccountNumber GetAccountNumber()
        {
            return accountNumber;
        }

        public ICompanyName GetCompanyName()
        {
            return companyName;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", companyName, accountNumber);
        }
    }
}