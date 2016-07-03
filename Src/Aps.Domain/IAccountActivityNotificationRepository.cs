using Aps.Domain.Notifications;

namespace Aps.Domain
{
    public interface IAccountActivityNotificationRepository
    {
        AccountActivityNotification GetById(AccountActivityNotificationId id);
        void Save(AccountActivityNotification accountActivityNotification);
    }
}
