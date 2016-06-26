using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Notifications
{
    public struct NotificationStatus
    {
        private enum NotificationStatusType
        {
            Unknown,
            Unread,
            Read,
            Actioned
        }

        private readonly NotificationStatusType status;

        public static NotificationStatus Unread { get { return new NotificationStatus(NotificationStatusType.Unread); } }
        public static NotificationStatus Read { get { return new NotificationStatus(NotificationStatusType.Read); } }

        private NotificationStatus(NotificationStatusType status)
        {
            this.status = status;
        }
    }
}
