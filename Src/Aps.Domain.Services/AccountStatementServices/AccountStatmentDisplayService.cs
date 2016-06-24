using Aps.Domain.AccountStatements;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;

namespace Aps.Domain.Services.AccountStatementServices
{
    public class AccountStatmentDisplayService
    {
        private readonly IAccountStatementRepository accountStatementRepository;
        private readonly IAccountStatmentDisplayAdapter displayAdapter;

        public AccountStatmentDisplayService(IAccountStatementRepository accountStatementRepository, IAccountStatmentDisplayAdapter displayAdapter)
        {
            Guard.ThatParameterNotNull(accountStatementRepository, "accountStatementRepository");
            Guard.ThatParameterNotNull(displayAdapter, "displayAdapter");

            this.accountStatementRepository = accountStatementRepository;
            this.displayAdapter = displayAdapter;
        }

        public void DisplayAccountStatementForMonth(IAccountId accountId, CalendarMonth month)
        {
            AccountStatement accountStatement = accountStatementRepository.FetchForAccountAndMonth(accountId, month);
            accountStatement.Display(displayAdapter);
        }
    }
}