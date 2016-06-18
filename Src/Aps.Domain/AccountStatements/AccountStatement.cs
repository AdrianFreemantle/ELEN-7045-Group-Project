using System.Collections.Generic;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public class AccountStatement
    {
        private readonly AccountStatementId id;
        private readonly ICollection<AccountStatmentEntry> accountStatmentEntries;

        //just to ensure that the default constructor can't be called
        protected AccountStatement()
        {
        }

        internal AccountStatement(AccountStatementId id, ICollection<AccountStatmentEntry> entries)
        {
            Guard.ThatValueTypeNotDefaut(id, "id");
            Guard.ThatParameterNotNull(entries, "entries");

            this.id = id;
            this.accountStatmentEntries = new List<AccountStatmentEntry>(entries); //we create a new list so as to not be affected by changes to the collection passed in
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