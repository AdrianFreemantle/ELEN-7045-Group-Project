namespace Aps.Domain.Account
{
    public struct AccountNumber
    {
        private readonly string accountnumber;

        public static AccountNumber Empty { get { return new AccountNumber(); } }

        public AccountNumber(string accountnumber)
        {

            this.accountnumber = accountnumber;
        }
    }
}