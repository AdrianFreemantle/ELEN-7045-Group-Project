using Aps.Domain.Common;
using Aps.Domain.Companies;
using Aps.Domain.Credential;
using Aps.Domain.Customers;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Account.Tests
{
    [TestClass]
    [FeatureDescription(@"Account activation")]
    public partial class Account_activation
    {
        [TestMethod]
        [ExpectedException(typeof(DomainException), "Account already exist.")]
        public void Customer_cannot_add_a_duplicate_account()
        {
            var customerid = new CustomerId(new EmailAddress("chrisv@live.co.za"));
            var first = new AccountId(new CompanyName("Acme Ltd"), new AccountNumber("1234567890"));
            var second = new AccountId(new CompanyName("Acme Ltd"), new AccountNumber("1234567890"));

            IEncryptionService encryptionService = new Encryption();
            var credentials = Credentials.Create(new EmailAddress("chrisv@live.co.za"), new Password("123", "123", encryptionService));

            Runner.RunScenario(
                given => customer(customerid),
                and => account_id(first),
                and => another_account_id(second),
                and => account_credentials(credentials),
                when => creating_an_account(),
                and => creating_another_account(),
                and => an_account_scraper_validation_succeeded(),
                and => another_account_scraper_validation_succeeded(),
                and => persisting_an_account_in_a_clean_repository(),
                and => persisting_another_account());
        }

        [TestMethod]
        public void Customer_can_add_multiple_different_accounts()
        {
            var customerid = new CustomerId(new EmailAddress("chrisv@live.co.za"));
            var first = new AccountId(new CompanyName("Acme Ltd"), new AccountNumber("123"));
            var second = new AccountId(new CompanyName("Acme Ltd"), new AccountNumber("456"));

            IEncryptionService encryptionService = new Encryption();
            var credentials = Credentials.Create(new EmailAddress("chrisv@live.co.za"), new Password("123", "123", encryptionService));

            Runner.RunScenario(
                given => customer(customerid),
                and => account_id(first),
                and => another_account_id(second),
                and => account_credentials(credentials),
                when => creating_an_account(),
                and => creating_another_account(),
                and => an_account_scraper_validation_succeeded(),
                and => another_account_scraper_validation_succeeded(),
                and => persisting_an_account_in_a_clean_repository(),
                and => persisting_another_account(),
                and => getting_the_total_accounts_persisted(),
                then => two_accounts_should_be_persisted());
        }

        [TestMethod]
        public void Customer_registered_account_with_invalid_accountnumber()
        {
            var customerid = new CustomerId(new EmailAddress("chrisv@live.co.za"));
            var first = new AccountId(new CompanyName("Acme Ltd"), new AccountNumber("XYZ"));

            IEncryptionService encryptionService = new Encryption();
            var credentials = Credentials.Create(new EmailAddress("chrisv@live.co.za"), new Password("123", "123", encryptionService));

            Runner.RunScenario(
                given => customer(customerid),
                and => account_id(first),
                and => account_credentials(credentials),
                when => creating_an_account(),
                and => an_account_scraper_validation_failed(),
                and => persisting_an_account_in_a_clean_repository(),
                and => getting_the_total_accounts_persisted(),
                then => zero_accounts_should_be_persisted());
        }

        [TestMethod]
        public void Customer_registered_account_with_valid_accountnumber()
        {
            var customerid = new CustomerId(new EmailAddress("chrisv@live.co.za"));
            var first = new AccountId(new CompanyName("Acme Ltd"), new AccountNumber("123456789"));

            IEncryptionService encryptionService = new Encryption();
            var credentials = Credentials.Create(new EmailAddress("chrisv@live.co.za"), new Password("123", "123", encryptionService));

            Runner.RunScenario(
                given => customer(customerid),
                and => account_id(first),
                and => account_credentials(credentials),
                when => creating_an_account(),
                and => an_account_scraper_validation_succeeded(),
                and => persisting_an_account_in_a_clean_repository(),
                and => getting_the_total_accounts_persisted(),
                then => one_accounts_should_be_persisted());
        }

    }
}
