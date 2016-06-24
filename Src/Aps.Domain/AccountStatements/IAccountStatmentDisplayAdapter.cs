using System.Collections.Generic;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public interface IAccountStatmentDisplayAdapter
    {
        void Display(IAccountNumber accountNumber, ICompanyName companyName, CalendarMonth billingMonth, IEnumerable<AccountStatementEntryDisplayValue> statementEntries);
    }
}