using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Notifications;
using Aps.Domain.Credential;

namespace Aps.Domain.Notifications
{
    public class AccountActivityNotificationFactory
    {
        public AccountActivityNotification Create(Account.Account account, NotificationType notificationType)
        {
            Guard.ThatValueTypeNotDefaut(account, "account");
            Guard.ThatValueTypeNotDefaut(notificationType, "notificationType");

            var id = AccountActivityNotificationId.Create();
            return new AccountActivityNotification(id, account.GetAccountId(), account.GetCustomerId(), notificationType);
        }
    }
}
