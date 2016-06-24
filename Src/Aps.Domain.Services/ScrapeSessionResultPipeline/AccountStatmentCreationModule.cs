using Aps.Domain.Scraping;
using Aps.Domain.Services.AccountStatementServices;

namespace Aps.Domain.Services.ScrapeSessionResultPipeline
{
    public class AccountStatmentCreationModule : IPipelineModule<ScrapeSessionResult>
    {
        private readonly AccountStatmentCreationService accountStatmentCreationService;

        public AccountStatmentCreationModule(AccountStatmentCreationService accountStatmentCreationService)
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