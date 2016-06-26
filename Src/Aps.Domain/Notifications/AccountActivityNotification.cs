using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps;
using Aps.Domain.Account;
using Aps.Domain.Credential;
using Aps.Domain.Customers;
using Aps.Domain.Notifications;

namespace Aps.Domain.Notifications
{
    public class AccountActivityNotification
    {
        private readonly AccountActivityNotificationId id;
        private AccountId accountId;
        private CustomerId customerId;
        private NotificationType notificationType;
        private NotificationStatus status;

        protected AccountActivityNotification()
        {
        }

        internal AccountActivityNotification(AccountActivityNotificationId id, AccountId accountId, CustomerId customerId, NotificationType notificationType)
        {
            Guard.ThatValueTypeNotDefaut(id, "id");
            Guard.ThatValueTypeNotDefaut(accountId, "accountId");
            Guard.ThatValueTypeNotDefaut(customerId, "customerId");
            Guard.ThatValueTypeNotDefaut(notificationType, "notificationType");

            this.id = id;
            this.accountId = accountId;
            this.customerId = customerId;
            this.notificationType = notificationType;
            status = NotificationStatus.Unread;
        }

        public void HasBeenRead()
        {
            status = NotificationStatus.Read;
        }

    }
}
