using System;
using System.Collections.Generic;
using System.Linq;
using Aps.Domain.AccountStatements.AccountStatementIntegrityChecks;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;
using Aps.Domain.Companies;
using Aps.Domain.Scraping;

namespace Aps.Domain.AccountStatements
{
    public class AccountStatementFactory
    {
        private readonly StatementEntryFactory statementEntryFactory;

        public AccountStatementFactory(StatementEntryFactory statementEntryFactory)
        {
            Guard.ThatParameterNotNull(statementEntryFactory, "accountStatementEntryFactory");

            this.statementEntryFactory = statementEntryFactory;
        }

        public AccountStatement CreateAccountStatement(ScrapeSessionResult scrapeSessionResult, ICollection<AccountStatementEntryMapping> mappings)
        {
            return CreateAccountStatement(scrapeSessionResult, mappings, new IDataIntegrityCheck[0], new IDataIntegrityCheckOverride[0]);
        }

        public AccountStatement CreateAccountStatement(ScrapeSessionResult scrapeSessionResult, ICollection<AccountStatementEntryMapping> mappings, ICollection<IDataIntegrityCheck> integrityChecks)
        {
            return CreateAccountStatement(scrapeSessionResult, mappings, integrityChecks, new IDataIntegrityCheckOverride[0]);
        }

        public AccountStatement CreateAccountStatement(ScrapeSessionResult scrapeSessionResult, ICollection<AccountStatementEntryMapping> mappings, ICollection<IDataIntegrityCheck> integrityChecks, ICollection<IDataIntegrityCheckOverride> integrityCheckOverrides)
        {
            Guard.ThatValueTypeNotDefaut(scrapeSessionResult, "scrapeSessionResult");
            Guard.ThatParameterNotNull(mappings, "mappings");
            Guard.ThatParameterNotNull(integrityChecks, "integrityChecks");
            Guard.ThatParameterNotNull(integrityCheckOverrides, "integrityCheckOverrides");
            Guard.ThatParameterNotNull(statementEntryFactory, "accountStatementEntryFactory");

            var entries = BuildAccountStatementEntries(scrapeSessionResult, mappings);

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

        private ICollection<StatementEntry> BuildAccountStatementEntries(ScrapeSessionResult scrapeSessionResult, ICollection<AccountStatementEntryMapping> mappings)
        {
            List<StatementEntry> entries = new List<StatementEntry>();

            foreach (ScrapeResultDataPair scrapeResultDataPair in scrapeSessionResult.TextValuePairs)
            {
                AccountStatementEntryMapping mapping = mappings.SingleOrDefault(m => m.FieldId.Equals(scrapeResultDataPair.Id)); //todo: throw appropriate error

                StatementEntry entry = statementEntryFactory.Build(mapping.EntryType, scrapeResultDataPair); 
                entries.Add(entry);
            }

            return entries;
        }
    }
}