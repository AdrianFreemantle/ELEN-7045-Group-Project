using System.Collections.Generic;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public interface IAccountStatementRepository
    {
        void Save(AccountStatement accountStatement);
        ICollection<AccountStatement> FetchAllForAccount(IAccountId accountId);
        AccountStatement FetchForAccountAndMonth(IAccountId accountId, CalendarMonth month);
    }
}