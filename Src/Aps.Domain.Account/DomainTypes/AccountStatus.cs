using System;

namespace Aps.Domain.Account.Tests.DomainTypes
{
    public class StatusNotificationRuleAttribute : Attribute
    {
        public bool ShouldNotifyCustomer { get; set; }
    }

    public struct AccountStatus
    {
        private enum AccountStatusType
        {
            [System.ComponentModel.Description("Unknown Account Status")]
            Unknown,
            [StatusNotificationRule(ShouldNotifyCustomer = true)]
            Active,
            Inactive,
            ThisIsComplex
        }

        private readonly AccountStatusType accountStatus;

        public static AccountStatus Idiot { get { return new AccountStatus(AccountStatusType.Unknown); } }
        public static AccountStatus Active { get { return new AccountStatus(AccountStatusType.Active); } }
        public static AccountStatus Inactive { get { return new AccountStatus(AccountStatusType.Inactive); } }
        public static AccountStatus ThisIsComplex { get { return new AccountStatus(AccountStatusType.ThisIsComplex); } }

        private AccountStatus(AccountStatusType accountStatus)
        {
            this.accountStatus = accountStatus;
        }

        public bool ShouldNotifyCustomer()
        {
            var attribute = accountStatus.TryGetCustomAttribute<StatusNotificationRuleAttribute>();

            if (attribute == null)
                return false;

            return attribute.ShouldNotifyCustomer;
        }

        public override string ToString()
        {
            return accountStatus.GetDescription();
        }
    }
}