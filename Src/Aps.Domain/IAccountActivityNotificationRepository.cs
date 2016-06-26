using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Notifications;

namespace Aps.Domain
{
    public interface IAccountActivityNotificationRepository
    {
        AccountActivityNotification GetById(AccountActivityNotificationId id);
        void Save(AccountActivityNotification accountActivityNotification);
    }
}
