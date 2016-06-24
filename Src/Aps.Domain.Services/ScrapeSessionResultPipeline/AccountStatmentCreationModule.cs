using Aps.Domain.AccountStatements;
using Aps.Domain.Scraping;

namespace Aps.Domain.Services.ScrapeSessionResultPipeline
{
    public class AccountStatmentCreationModule : IPipelineModule<ScrapeSessionResult>
    {
        private readonly IAccountStatmentCreationService accountStatmentCreationService;

        public AccountStatmentCreationModule(IAccountStatmentCreationService accountStatmentCreationService)
        {
            Guard.ThatParameterNotNull(accountStatmentCreationService, "accountStatmentCreationService");
            this.accountStatmentCreationService = accountStatmentCreationService;
        }

        public void Process(ScrapeSessionResult scrapeSessionResult)
        {
            if (scrapeSessionResult.ResultCode.Equals(ScrapeSessionResultCode.Complete))
            {
                accountStatmentCreationService.CreateAccountStatementFromScrapeResult(scrapeSessionResult);
            }
        }
    }
}