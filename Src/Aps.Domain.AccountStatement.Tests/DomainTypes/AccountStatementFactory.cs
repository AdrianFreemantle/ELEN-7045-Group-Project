using Aps.Domain.AccountStatements;

namespace Aps.Domain.AccountStatements.Tests.DomainTypes
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