using Aps.Domain.Account.Tests.DomainTypes;
using Aps.Domain.Customers;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Account.Tests
{
    public partial class Account_activation : FeatureFixture
    {
        private CustomerId _customerId;
        private AccountId _accountid1;
        private AccountId _accountid2;
        private Credentials _credentials;
        private Account firstAccount;
        private Account secondAccount;
        private bool _scapervalidation1 = false;
        private bool _scapervalidation2 = false;
        AccountRepository accountRepository = new AccountRepository();


        private int _totAccounts;

        private void another_account_id(AccountId id)
        {
            _accountid2 = id;
        }

        private void account_id(AccountId id)
        {
            _accountid1 = id;
        }

        private void customer(CustomerId customerid)
        {
            _customerId = customerid;
        }

        private void account_credentials(Credentials credentials)
        {
            _credentials = credentials;
        }

        //To-Do Add interaction between scraper
        private void an_account_scraper_validation_succeeded()
        {
            myScraper scraper = new myScraper();
            _scapervalidation1 = scraper.ValidateAccount(_customerId, firstAccount, _credentials);
            _scapervalidation1.ShouldBe(true);
        }
        //To-Do Add interaction between scraper
        private void another_account_scraper_validation_succeeded()
        {
            myScraper scraper = new myScraper();
            _scapervalidation2 = scraper.ValidateAccount(_customerId, secondAccount, _credentials);
            _scapervalidation2.ShouldBe(true);
        }

        //To-Do Add interaction between scraper
        private void an_account_scraper_validation_failed()
        {
            myScraper scraper = new myScraper();
            _scapervalidation1 = scraper.ValidateAccount(_customerId, firstAccount, _credentials);
            _scapervalidation1.ShouldBe(false);
        }
        //To-Do Add interaction between scraper
        private void another_account_scraper_validation_failed()
        {
            myScraper scraper = new myScraper();
            _scapervalidation2 = scraper.ValidateAccount(_customerId, secondAccount, _credentials);
            _scapervalidation2.ShouldBe(false);
        }
   
        private void creating_an_account()
        {
            AccountFactory accountFactory = new AccountFactory();
            firstAccount = accountFactory.CreateAccount(_customerId, _accountid1, _credentials);
        }

        private void creating_another_account()
        {
            AccountFactory accountFactory = new AccountFactory();
            secondAccount = accountFactory.CreateAccount(_customerId, _accountid2, _credentials);
        }

        private void persisting_an_account()
        {
            if (_scapervalidation1)
                accountRepository.SaveAccount(firstAccount);
        }
        private void persisting_another_account()
        {
            if (_scapervalidation1)
                accountRepository.SaveAccount(secondAccount);
        }

        private void getting_the_total_accounts_persisted()
        {
            _totAccounts = accountRepository.Count();            
        }

        private void then_two_accounts_should_be_persisted()
        {
            _totAccounts.ShouldBe(2);
        }
        private void then_zero_accounts_should_be_persisted()
        {
            _totAccounts.ShouldBe(0);
        }
    }
}
