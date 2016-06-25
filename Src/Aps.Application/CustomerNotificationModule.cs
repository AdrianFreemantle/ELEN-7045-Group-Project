using Aps.Domain.Notifications;
using Aps.Domain.Scraping;

namespace Aps.Application
{
    public class CustomerNotificationModule : IPipelineModule<ScrapeSessionResult>
    {
        private readonly INotificationService notificationService;

        public CustomerNotificationModule(INotificationService notificationService)
        {
            Guard.ThatParameterNotNull(notificationService, "notificationService");
            this.notificationService = notificationService;
        }

        public void Process(ScrapeSessionResult scrapeSessionResult)
        {
            if (scrapeSessionResult.ResultCode.Equals(ScrapeSessionResultCode.InvalidCredentials))
            {
                notificationService.NotifyCustomerOfInvalidCredentialsForAccount(scrapeSessionResult.AccountId);
            }
        }
    }
}