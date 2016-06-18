using System.Collections.Generic;
using Aps.Domain.Common;
using Aps.Domain.Scraping;

namespace Aps.Domain.AccountStatements
{
    public class AccountStatementFactory
    {
        readonly AccountStatmentEntryFactory accountStatmentEntryFactory = new AccountStatmentEntryFactory();

        public AccountStatement CreateAccountStatement(ScrapeSessionResult scrapeSessionResult)
        {
            var callCalendarMonth = new CalendarMonth(scrapeSessionResult.RunDateTime);
            var accountId = scrapeSessionResult.AccountId;
            var accountStatementId = AccountStatementId.Create(accountId, callCalendarMonth);

            List<AccountStatmentEntry> entries = new List<AccountStatmentEntry>();

            foreach (var scrapeResultDataPair in scrapeSessionResult.TextValuePairs)
            {
                var a = AccountStatmentEntryType.DueDate;
                accountStatmentEntryFactory.Build(a, scrapeResultDataPair);
            }

            return new AccountStatement(accountStatementId, entries);
        }
    }
}