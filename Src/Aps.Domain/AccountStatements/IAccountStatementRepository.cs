using System.Collections.Generic;

namespace Aps.Domain.AccountStatements
{
    public interface IAccountStatementRepository
    {
        void Save(AccountStatement accountStatement);
        ICollection<AccountStatement> FetchAllForAccount(IAccountId accountId);
    }
}