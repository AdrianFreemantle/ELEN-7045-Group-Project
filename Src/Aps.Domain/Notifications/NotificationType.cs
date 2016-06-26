using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Notifications
{
    public struct NotificationType
    {

        private enum NotificationTypeEnum
        {
            Unknown,
            InvalidAccountCredentials
        }

        private readonly NotificationTypeEnum notificationType;

        public static NotificationType InvalidAccountCredentials { get { return new NotificationType(NotificationTypeEnum.InvalidAccountCredentials); } }

        private NotificationType(NotificationTypeEnum notificationType)
        {
            this.notificationType = notificationType;
        }
    }
}
