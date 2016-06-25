namespace Aps.Domain.Account
{
    public interface IAccountStatusUpdateService
    {
        void ActivateAccount(IAccountId accountId);
    }
}