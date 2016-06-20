using System;

namespace Aps.Domain.Account.Tests.DomainTypes
{
    public interface IAccount
    {
        ICustomerId CustomerId { get; set; }
        AccountId AccountId { get; set; }
        ICredentials Credentials { get; set; }
        DateTime DateAdded { get; set; }
        AccountStatus AccountStatus { get; set; }

        bool Add(ICustomerId customerId, IAccountId accountId, ICredentials credentials);
        bool Remove(ICustomerId customerId, IAccountId accountId);
        bool UpdateCredentials(ICustomerId customerId, IAccountId accountId, ICredentials credentials);
        bool SetAccountStatus(ICustomerId customerId, IAccountId accountId, AccountStatus accountStatus);

    }
}
