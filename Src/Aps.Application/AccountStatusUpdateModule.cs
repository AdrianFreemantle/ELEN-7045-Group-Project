using Aps.Domain.Account;
using Aps.Domain.Scraping;

namespace Aps.Application
{
    public class AccountStatusUpdateModule : IPipelineModule<ScrapeSessionResult>
    {
        private readonly IAccountStatusUpdateService accountStatusUpdateService;

        public AccountStatusUpdateModule(IAccountStatusUpdateService accountStatusUpdateService)
        {
            Guard.ThatParameterNotNull(accountStatusUpdateService, "accountStatusUpdateService");
            this.accountStatusUpdateService = accountStatusUpdateService;
        }

        public void Process(ScrapeSessionResult scrapeSessionResult)
        {
            if (scrapeSessionResult.ResultCode.Equals(ScrapeSessionResultCode.InvalidCredentials))
            {
               accountStatusUpdateService.ActivateAccount(scrapeSessionResult.AccountId);
            }
            else if (scrapeSessionResult.ResultCode.Equals(ScrapeSessionResultCode.Complete))
            {
                accountStatusUpdateService.ActivateAccount(scrapeSessionResult.AccountId);
            }
        }
    }
}