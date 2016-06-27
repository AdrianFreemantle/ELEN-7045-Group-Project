using System.Collections.Generic;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public interface IAccountStatementDisplayAdapter
    {
        void Display(IAccountNumber accountNumber, ICompanyName companyName, CalendarMonth billingMonth, IEnumerable<StatementEntryDisplayValue> statementEntries);
    }
}