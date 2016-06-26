using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain;

namespace Aps.Domain.Notifications
{
    public struct AccountActivityNotificationId : IIdentificationField
    {
        private readonly Guid id;

        private AccountActivityNotificationId(Guid id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return id.ToString();
        }

        public static AccountActivityNotificationId Create()
        {
            return new AccountActivityNotificationId(Guid.NewGuid());
        }
    }
}
