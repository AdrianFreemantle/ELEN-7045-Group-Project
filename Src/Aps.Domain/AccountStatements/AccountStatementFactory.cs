using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public class AccountStatementFactory
    {
        public AccountStatement CreateAccountStatement(IScrapeSessionResult scrapeSessionResult)
        {
            var callCalendarMonth = new CalendarMonth(scrapeSessionResult.RunDateTime);
            var accountId = scrapeSessionResult.AccountId;

            var accountStatementId = AccountStatementId.Create(accountId, callCalendarMonth);

            return new AccountStatement(accountStatementId);
        }
    }
}