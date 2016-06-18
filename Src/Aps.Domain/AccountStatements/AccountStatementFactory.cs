using System;
using System.Collections.Generic;
using System.Linq;
using Aps.Domain.Common;
using Aps.Domain.Company;
using Aps.Domain.Scraping;

namespace Aps.Domain.AccountStatements
{
    public class AccountStatementFactory
    {
        readonly AccountStatmentEntryFactory accountStatmentEntryFactory = new AccountStatmentEntryFactory();
        private readonly ICollection<IDataIntegrityCheck> integrityChecks;
        private readonly ICollection<IDataIntegrityCheckOverride> integrityCheckOverrides;

        public AccountStatementFactory()
            : this(new IDataIntegrityCheck[0], new IDataIntegrityCheckOverride[0])
        {
        }

        public AccountStatementFactory(ICollection<IDataIntegrityCheck> integrityChecks)
            :this(integrityChecks, new IDataIntegrityCheckOverride[0])
        {
        }

        public AccountStatementFactory(ICollection<IDataIntegrityCheck> integrityChecks, ICollection<IDataIntegrityCheckOverride> integrityCheckOverrides)
        {
            Guard.ThatParameterNotNull(integrityChecks, "integrityChecks");
            Guard.ThatParameterNotNull(integrityCheckOverrides, "integrityCheckOverrides");

            this.integrityChecks = integrityChecks;
            this.integrityCheckOverrides = integrityCheckOverrides;
        }

        public AccountStatement CreateAccountStatement(ScrapeSessionResult scrapeSessionResult)
        {
            var entries = BuildAccountStatmentEntries(scrapeSessionResult);

            foreach (var integrityCheck in integrityChecks.Where(i => !integrityCheckOverrides.Any(o => o.Override(i))))
            {
                if (!integrityCheck.IsValid(entries))
                {
                    string integrityCheckName = integrityCheck.GetType().Name.SplitCamelCase();
                    var errorMessage = String.Format("Data integrity check '{0}' failed", integrityCheckName);
                    throw new DataIntegrityCheckFailedException(errorMessage);
                }
            }

            var callCalendarMonth = new CalendarMonth(scrapeSessionResult.RunDateTime);
            var accountId = scrapeSessionResult.AccountId;
            var accountStatementId = AccountStatementId.Create(accountId, callCalendarMonth);

            return new AccountStatement(accountStatementId, entries);
        }

        private List<AccountStatmentEntry> BuildAccountStatmentEntries(ScrapeSessionResult scrapeSessionResult)
        {
            List<AccountStatmentEntry> entries = new List<AccountStatmentEntry>();

            foreach (var scrapeResultDataPair in scrapeSessionResult.TextValuePairs)
            {
                var a = AccountStatmentEntryType.DueDate;
                accountStatmentEntryFactory.Build(a, scrapeResultDataPair);
            }
            return entries;
        }
    }
}