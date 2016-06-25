namespace Aps.Domain.Account
{
    public struct AccountStatusUpdateService
    {
        public void ActivateAccount(AccountId accountId)
        {
            AccountRepository accountRepository = new AccountRepository();
            Account account = accountRepository.GetAccount(accountId);
            account.SetAccountStatus(new AccountStatus(AccountStatus.AccountStatusType.Active));
        }
        public void DeactivateAccount(AccountId accountId)
        {
            AccountRepository accountRepository = new AccountRepository();
            Account account = accountRepository.GetAccount(accountId);
            account.SetAccountStatus(new AccountStatus(AccountStatus.AccountStatusType.Inactive));            
        }
        public void RequestAccountCredentials(AccountId accountId)
        {
            AccountRepository accountRepository = new AccountRepository();
            Account account = accountRepository.GetAccount(accountId);
            account.SetAccountStatus(new AccountStatus(AccountStatus.AccountStatusType.UpdateCredentials));            
        }
        public void RequestAccountEBillingSignUpRequired(AccountId accountId)
        {
            AccountRepository accountRepository = new AccountRepository();
            Account account = accountRepository.GetAccount(accountId);
            account.SetAccountStatus(new AccountStatus(AccountStatus.AccountStatusType.NotSignedUpForEBilling));            
        }
        public void RequestAccountActionRquired(AccountId accountId)
        {
            AccountRepository accountRepository = new AccountRepository();
            Account account = accountRepository.GetAccount(accountId);
            account.SetAccountStatus(new AccountStatus(AccountStatus.AccountStatusType.ActionRequired));  
        }
    }
}