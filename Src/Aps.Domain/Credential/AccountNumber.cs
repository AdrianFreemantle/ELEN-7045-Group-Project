namespace Aps.Domain.Credential
{
    public struct AccountNumber :IAccountNumber
    {
        private readonly string accountnumber;

        public static AccountNumber Empty { get { return new AccountNumber(); } }

        public AccountNumber(string accountnumber)
        {

            this.accountnumber = accountnumber;
        }

        public override string ToString()
        {
            return accountnumber;
        }
    }
}