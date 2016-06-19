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
        private readonly ICollection<AccountStatmentEntryMapping> mappings;
        private readonly ICollection<IDataIntegrityCheck> integrityChecks;
        private readonly ICollection<IDataIntegrityCheckOverride> integrityCheckOverrides;

        public AccountStatementFactory(AccountStatmentEntryFactory accountStatmentEntryFactory, ICollection<AccountStatmentEntryMapping> mappings)
            : this(accountStatmentEntryFactory, mappings, new IDataIntegrityCheck[0], new IDataIntegrityCheckOverride[0])
        {
        }

        public AccountStatementFactory(AccountStatmentEntryFactory accountStatmentEntryFactory, ICollection<AccountStatmentEntryMapping> mappings, ICollection<IDataIntegrityCheck> integrityChecks)
            :this(accountStatmentEntryFactory, mappings, integrityChecks, new IDataIntegrityCheckOverride[0])
        {
        }

        public AccountStatementFactory(AccountStatmentEntryFactory accountStatmentEntryFactory, ICollection<AccountStatmentEntryMapping> mappings, ICollection<IDataIntegrityCheck> integrityChecks, ICollection<IDataIntegrityCheckOverride> integrityCheckOverrides)
        {
            Guard.ThatParameterNotNull(integrityChecks, "integrityChecks");
            Guard.ThatParameterNotNull(integrityCheckOverrides, "integrityCheckOverrides");
            Guard.ThatParameterNotNull(accountStatmentEntryFactory, "accountStatmentEntryFactory");
            Guard.ThatParameterNotNull(mappings, "mappings");

            this.accountStatmentEntryFactory = accountStatmentEntryFactory;
            this.mappings = mappings;
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

        private ICollection<AccountStatmentEntry> BuildAccountStatmentEntries(ScrapeSessionResult scrapeSessionResult)
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