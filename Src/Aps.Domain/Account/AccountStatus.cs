using System;

namespace Aps.Domain.Account
{
    public class StatusNotificationRuleAttribute : Attribute
    {
        public bool ShouldNotifyCustomer { get; set; }
    }

    public struct AccountStatus
    {
        public enum AccountStatusType
        {
            [System.ComponentModel.Description("Unknown Account Status")]
            Unknown,
            Register,
            [StatusNotificationRule(ShouldNotifyCustomer = true)]
            Active,
            Inactive,
            UpdateCredentials,
            NotSignedUpForEBilling,
            ActionRequired,
        }

        private readonly AccountStatusType accountStatus;

        public static AccountStatus Unknown { get { return new AccountStatus(AccountStatusType.Unknown); } }
        public static AccountStatus Register { get { return new AccountStatus(AccountStatusType.Register); } }
        public static AccountStatus Active { get { return new AccountStatus(AccountStatusType.Active); } }
        public static AccountStatus Inactive { get { return new AccountStatus(AccountStatusType.Inactive); } }
        public static AccountStatus UpdateCredentials { get { return new AccountStatus(AccountStatusType.UpdateCredentials); } }
        public static AccountStatus NotSignedUpForEBilling { get { return new AccountStatus(AccountStatusType.NotSignedUpForEBilling); } }
        public static AccountStatus ActionRequired { get { return new AccountStatus(AccountStatusType.ActionRequired); } }

        public AccountStatus(AccountStatusType accountStatus)
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