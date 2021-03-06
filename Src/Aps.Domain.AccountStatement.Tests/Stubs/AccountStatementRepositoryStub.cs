using System;
using System.Collections.Generic;
using System.Linq;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.Tests.Stubs
{
    public class AccountStatementRepositoryStub : IAccountStatementRepository
    {
        private readonly List<AccountStatement> savedAccountStatements = new List<AccountStatement>();
 
        public void Save(AccountStatement accountStatement)
        {
            Guard.ThatParameterNotNull(accountStatement, "accountStatement");

            savedAccountStatements.Add(accountStatement);
        }

        public ICollection<AccountStatement> FetchAllForAccount(IAccountId accountId)
        {
            return savedAccountStatements
                .Where(a => a.IsForAccount(accountId))
                .ToArray();
        }

        public AccountStatement FetchForAccountAndMonth(IAccountId accountId, CalendarMonth month)
        {
            throw new NotImplementedException();
        }
    }
}