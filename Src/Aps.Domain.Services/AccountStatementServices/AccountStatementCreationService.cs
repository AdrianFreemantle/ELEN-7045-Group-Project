using System.Collections.Generic;
using System.Linq;
using Aps.Domain.AccountStatements;
using Aps.Domain.Companies;
using Aps.Domain.Scraping;

namespace Aps.Domain.Services.AccountStatementServices
{
    public class AccountStatementCreationService : AccountStatements.IAccountStatementCreationService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IAccountStatementRepository accountStatementRepository;

        public AccountStatementCreationService(IAccountStatementRepository accountStatementRepository, ICompanyRepository companyRepository)
        {
            Guard.ThatParameterNotNull(accountStatementRepository, "accountStatementRepository");
            Guard.ThatParameterNotNull(companyRepository, "companyRepository");

            this.accountStatementRepository = accountStatementRepository;
            this.companyRepository = companyRepository;
        }

        public void CreateAccountStatementFromScrapeResult(ScrapeSessionResult scrapeSessionResult)
        {
            var accountStatementEntryFactory = new StatementEntryFactory();
            var accountStatementFactory = new AccountStatementFactory(accountStatementEntryFactory);

            var companyName = scrapeSessionResult.AccountId.CompanyName;
            Company company = companyRepository.FetchByName(companyName);

            var mappings = company.Mappings.ToArray();
            var integrityChecks = company.IntegrityChecks.ToArray();
            var integrityCheckOverrides = company.IntegrityCheckOverrides.ToArray();

            var accountStatement = accountStatementFactory.CreateAccountStatement(scrapeSessionResult, mappings, integrityChecks, integrityCheckOverrides);
            accountStatementRepository.Save(accountStatement);
        }
    }
}