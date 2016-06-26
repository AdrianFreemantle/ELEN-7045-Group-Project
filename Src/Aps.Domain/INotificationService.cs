using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain
{
    public interface INotificationService
    {
        void NotifyCustomerOfInvalidCredentialsForAccount(IAccountId accountId);
    }
}
