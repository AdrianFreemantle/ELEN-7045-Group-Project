using System;
using System.Collections.Generic;
using System.Linq;
using Aps.Domain.AccountStatements.DataIntegrityChecks;
using Aps.Domain.Common;
using Aps.Domain.Company;
using Aps.Domain.Scraping;

namespace Aps.Domain.AccountStatements
{
    public class AccountStatementFactory
    {
        private readonly AccountStatmentEntryFactory accountStatmentEntryFactory;

        public AccountStatementFactory(AccountStatmentEntryFactory accountStatmentEntryFactory)
        {
            Guard.ThatParameterNotNull(accountStatmentEntryFactory, "accountStatmentEntryFactory");

            this.accountStatmentEntryFactory = accountStatmentEntryFactory;
        }

        public AccountStatement CreateAccountStatement(ScrapeSessionResult scrapeSessionResult, ICollection<AccountStatmentEntryMapping> mappings)
        {
            return CreateAccountStatement(scrapeSessionResult, mappings, new IDataIntegrityCheck[0], new IDataIntegrityCheckOverride[0]);
        }

        public AccountStatement CreateAccountStatement(ScrapeSessionResult scrapeSessionResult, ICollection<AccountStatmentEntryMapping> mappings, ICollection<IDataIntegrityCheck> integrityChecks)
        {
            return CreateAccountStatement(scrapeSessionResult, mappings, integrityChecks, new IDataIntegrityCheckOverride[0]);
        }

        public AccountStatement CreateAccountStatement(ScrapeSessionResult scrapeSessionResult, ICollection<AccountStatmentEntryMapping> mappings, ICollection<IDataIntegrityCheck> integrityChecks, ICollection<IDataIntegrityCheckOverride> integrityCheckOverrides)
        {
            Guard.ThatValueTypeNotDefaut(scrapeSessionResult, "scrapeSessionResult");
            Guard.ThatParameterNotNull(mappings, "mappings");
            Guard.ThatParameterNotNull(integrityChecks, "integrityChecks");
            Guard.ThatParameterNotNull(integrityCheckOverrides, "integrityCheckOverrides");
            Guard.ThatParameterNotNull(accountStatmentEntryFactory, "accountStatmentEntryFactory");

            var entries = BuildAccountStatmentEntries(scrapeSessionResult, mappings);

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

        private ICollection<AccountStatmentEntry> BuildAccountStatmentEntries(ScrapeSessionResult scrapeSessionResult, ICollection<AccountStatmentEntryMapping> mappings)
        {
            List<AccountStatmentEntry> entries = new List<AccountStatmentEntry>();

            foreach (ScrapeResultDataPair scrapeResultDataPair in scrapeSessionResult.TextValuePairs)
            {
                AccountStatmentEntryMapping mapping = mappings.SingleOrDefault(m => m.FieldId.Equals(scrapeResultDataPair.Id)); //todo: throw appropriate error

                AccountStatmentEntry entry = accountStatmentEntryFactory.Build(mapping.EntryType, scrapeResultDataPair); 
                entries.Add(entry);
            }

            return entries;
        }
    }
}