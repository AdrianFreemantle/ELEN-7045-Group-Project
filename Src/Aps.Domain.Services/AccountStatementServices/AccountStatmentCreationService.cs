using System.Collections.Generic;
using Aps.Domain.AccountStatements;
using Aps.Domain.Company;
using Aps.Domain.Scraping;

namespace Aps.Domain.Services.AccountStatementServices
{
    public class AccountStatmentCreationService
    {
        private readonly IAccountStatementRepository accountStatementRepository;
        private readonly List<IDataIntegrityCheck> integrityChecks;
        private readonly List<IDataIntegrityCheckOverride> integrityCheckOverrides;
        private readonly List<AccountStatmentEntryMapping> mappings;

        //todo need the company repository

        public AccountStatmentCreationService(IAccountStatementRepository accountStatementRepository)
        {
            this.accountStatementRepository = accountStatementRepository;
            this.integrityChecks = new List<IDataIntegrityCheck>();
            this.integrityCheckOverrides = new List<IDataIntegrityCheckOverride>();
            this.mappings = new List<AccountStatmentEntryMapping>();
        }

        public void CreateAccountStatementFromScrapeResult(ScrapeSessionResult scrapeSessionResult)
        {
            var accountStatmentEntryFactory = new StatmentEntryFactory();
            var accountStatementFactory = new AccountStatementFactory(accountStatmentEntryFactory);
            var accountStatment = accountStatementFactory.CreateAccountStatement(scrapeSessionResult, mappings, integrityChecks, integrityCheckOverrides);
            accountStatementRepository.Save(accountStatment);
        }
    }
}