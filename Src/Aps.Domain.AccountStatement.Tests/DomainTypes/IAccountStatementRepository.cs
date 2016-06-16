using System.Collections.Generic;

namespace Aps.Domain.AccountStatements.Tests.DomainTypes
{
    interface IAccountStatementRepository
    {
        void Save(AccountStatement accountStatement);
        ICollection<AccountStatement> FetchAllForAccount(IAccountId accountId);
    }
}