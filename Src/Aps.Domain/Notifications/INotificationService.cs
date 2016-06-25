namespace Aps.Domain.Notifications
{
    public interface INotificationService
    {
        void NotifyCustomerOfInvalidCredentialsForAccount(IAccountId accountId);
    }
}