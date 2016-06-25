using Aps.Domain.AccountStatements;
using Aps.Domain.Scraping;

namespace Aps.Application
{
    public class AccountStatementCreationModule : IPipelineModule<ScrapeSessionResult>
    {
        private readonly IAccountStatementCreationService accountStatementCreationService;

        public AccountStatementCreationModule(IAccountStatementCreationService accountStatementCreationService)
        {
            Guard.ThatParameterNotNull(accountStatementCreationService, "accountStatementCreationService");
            this.accountStatementCreationService = accountStatementCreationService;
        }

        public void Process(ScrapeSessionResult scrapeSessionResult)
        {
            if (scrapeSessionResult.ResultCode.Equals(ScrapeSessionResultCode.Complete))
            {
                accountStatementCreationService.CreateAccountStatementFromScrapeResult(scrapeSessionResult);
            }
        }
    }
}