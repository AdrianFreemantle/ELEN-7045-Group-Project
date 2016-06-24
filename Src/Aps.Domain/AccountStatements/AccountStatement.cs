using System.Collections.Generic;
using System.Linq;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;
using Aps.Domain.Company;
using Aps.Domain.Credential;

namespace Aps.Domain.AccountStatements
{
    public class AccountStatement
    {
        private readonly AccountStatementId id;
        private readonly ICollection<StatmentEntry> accountStatmentEntries;

        //just to ensure that the default constructor can't be called
        protected AccountStatement()
        {
        }

        internal AccountStatement(AccountStatementId id, ICollection<StatmentEntry> entries)
        {
            Guard.ThatValueTypeNotDefaut(id, "id");
            Guard.ThatParameterNotNull(entries, "entries");

            this.id = id;
            this.accountStatmentEntries = new List<StatmentEntry>(entries); //we create a new list so as to not be affected by changes to the collection passed in
        }

        public void Display(IAccountStatmentDisplayAdapter displayAdapter)
        {
            IEnumerable<StatementEntryDisplayValue> displayValues = accountStatmentEntries.Select(e => e.GetDisplayValue());
            displayAdapter.Display(id.AccountNumber, id.CompanyName, id.CalendarMonth, displayValues);
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

        public CalendarMonth StatementMonth()
        {
            return id.CalendarMonth;
        }

        public IAccountId AccountId()
        {
            return id.AccountId;
        }

        public bool IsForMonth(CalendarMonth month)
        {
            return id.CalendarMonth.Equals(month);
        }

        public bool IsForAccount(IAccountId accountId)
        {
            return id.AccountId.Equals(accountId);
        }
    }
}