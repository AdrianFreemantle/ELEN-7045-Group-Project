using System;
using System.Collections.Generic;
using Aps.Domain.AccountStatements.AccountStatementIntegrityChecks;
using Aps.Domain.Common;
using Aps.Domain.Company;
using Aps.Domain.Scraping;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.AccountStatements.Tests
{
    public partial class Account_statement_integrity_checks : FeatureFixture
    {
        private List<IDataIntegrityCheck> dataIntegrityChecks;
        private List<AccountStatmentEntryMapping> mappings;
        private List<ScrapeResultDataPair> textValuePairs;

        private AccountStatementFactory accountStatementFactory;
        private StatmentEntryFactory statmentEntryFactory;
        private ScrapeSessionResult scrapeSessionResult;
        private ScrapeSessionResultCode resultCode;
        private AccountStatement accountStatment;
        private IAccountId accountId;
        private DataIntegrityCheckFailedException dataIntegrityCheckFailedException;

        [TestInitialize]
        public void Initialize()
        {
            dataIntegrityChecks = new List<IDataIntegrityCheck>();
            mappings = new List<AccountStatmentEntryMapping>();
            textValuePairs = new List<ScrapeResultDataPair>();
        }

        private void a_mapping_code_id_for_entryType(string id, StatmentEntryType entryType)
        {
            var mapping = AccountStatmentEntryMapping.MapNumericValue(entryType, id);
            mappings.Add(mapping);
        }

        private void a_scrape_result_data_pair_with_id_and_description_and_value(string id, string description, string value)
        {
            var scrapeResultDataPair = new ScrapeResultDataPair(id, description, value);
            textValuePairs.Add(scrapeResultDataPair);
        }

        private void a_successfull_scrape_session_for_account_id(IAccountId id)
        {
            accountId = id;
            resultCode = ScrapeSessionResultCode.Complete;
        }

        public void creating_an_account_statment()
        {
            try
            {
                scrapeSessionResult = new ScrapeSessionResult(resultCode, accountId, DateTime.Now, textValuePairs);
                IDataIntegrityCheck check = new AdditionIntegrityCheck();
                dataIntegrityChecks.Add(check);
                statmentEntryFactory = new StatmentEntryFactory();
                accountStatementFactory = new AccountStatementFactory(statmentEntryFactory);
                accountStatment = accountStatementFactory.CreateAccountStatement(scrapeSessionResult, mappings, dataIntegrityChecks);
            }
            catch (DataIntegrityCheckFailedException ex)
            {
                dataIntegrityCheckFailedException = ex;
            }
        }

        public void Integrity_check_passed()
        {
            Assert.IsNull(dataIntegrityCheckFailedException);
        }

        public void Integrity_check_failed()
        {
            Assert.IsNotNull(dataIntegrityCheckFailedException);
        }
    }
}