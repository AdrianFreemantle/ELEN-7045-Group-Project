using System;
using Aps.Domain.Companies;
using Aps.Domain.Credential;

namespace Aps.Domain.Account
{
    public struct AccountId
    {
        private readonly AccountNumber accountNumber;
        private readonly CompanyName companyName;

        public  AccountId(CompanyName companyName, AccountNumber accountNumber)
        {
            Guard.ThatValueTypeNotDefaut(companyName, "companyName");
            Guard.ThatValueTypeNotDefaut(accountNumber, "accountNumber");

            this.companyName = companyName;
            this.accountNumber = accountNumber;
        }

        public AccountNumber GetAccountNumber()
        {
            return accountNumber;
        }

        public CompanyName GetCompanyName()
        {
            return companyName;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", companyName, accountNumber);
        }
    }
}