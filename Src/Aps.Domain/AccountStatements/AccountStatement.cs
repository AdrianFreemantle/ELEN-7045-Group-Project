using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public class AccountStatement
    {
        private readonly AccountStatementId id;

        //just to ensure that the default constructor can't be called
        protected AccountStatement()
        {
        }

        internal AccountStatement(AccountStatementId id)
        {
            this.id = id;
        }

        public bool Equals(AccountStatementId other)
        {
            return id.Equals(other);
        }

        public bool Equals(AccountStatement other)
        {
            if (other == null)
                return false;

            return Equals(other.id);
        }

        public bool IsForMonth(CalendarMonth month)
        {
            return id.Month.Equals(month);
        }

        public bool IsForAccount(IAccountId accountId)
        {
            return id.AccountId.Equals(accountId);
        }
    }
}