using Aps.Domain.Account;
using Aps.Domain.Notifications;

namespace Aps.Domain.Services.NotificationServices
{
    public class AccountActivityNotificationService
    {
        private readonly IAccountRepository accountRepository;
        private readonly AccountActivityNotificationFactory factory;
        private readonly IAccountActivityNotificationRepository accountActivityNotificationRepository;

        public AccountActivityNotificationService(
            IAccountActivityNotificationRepository accountActivityNotificationRepository,
            IAccountRepository accountRepository)
        {
            Guard.ThatParameterNotNull(accountRepository, "accountRepository");
            Guard.ThatParameterNotNull(accountActivityNotificationRepository, "accountActivityNotificationRepository");
            this.accountRepository = accountRepository;
            this.accountActivityNotificationRepository = accountActivityNotificationRepository;

            factory = new AccountActivityNotificationFactory();
        }

        public void NotifyCustomerOfInvalidCredentialsForAccount(AccountId accountId)
        {
            Guard.ThatValueTypeNotDefaut(accountId, "accountId");
            Account.Account account = accountRepository.FetchById(accountId);

            var notifcation = factory.Create(account, NotificationType.InvalidAccountCredentials);
            accountActivityNotificationRepository.Save(notifcation);

        }
    }
}
