﻿using Aps.Domain.Account.Tests.DomainTypes;
using Aps.Domain.Account.Tests.Stubs;
using Aps.Domain.Common;
using Aps.Domain.Credential;
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
            var customerid = new CustomerIdStub("Piet van Zyl");
            var first = AccountId.Create(new CompanyNameStub("Acme Ltd"), new AccountNumber("1234567890"));
            var second = AccountId.Create(new CompanyNameStub("Acme Ltd"), new AccountNumber("1234567890"));

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
                and => persisting_an_account(),
                and => persisting_another_account());
        }

        [TestMethod]
        public void Customer_can_add_multiple_different_accounts()
        {
            var customerid = new CustomerIdStub("Piet van Zyl");
            var first = AccountId.Create(new CompanyNameStub("Acme Ltd"), new AccountNumber("123"));
            var second = AccountId.Create(new CompanyNameStub("Acme Ltd"), new AccountNumber("456"));

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
                and => persisting_an_account(),
                and => persisting_another_account(),
                and => getting_the_total_accounts_persisted(),
                then => then_two_accounts_should_be_persisted());
        }

        [TestMethod]
        public void Customer_registered_account_with_invalid_accountnumber()
        {
            var customerid = new CustomerIdStub("Piet van Zyl");
            var first = AccountId.Create(new CompanyNameStub("Acme Ltd"), new AccountNumber("XYZ"));

            IEncryptionService encryptionService = new Encryption();
            var credentials = Credentials.Create(new EmailAddress("chrisv@live.co.za"), new Password("123", "123", encryptionService));

            Runner.RunScenario(
                given => customer(customerid),
                and => account_id(first),
                and => account_credentials(credentials),
                when => creating_an_account(),
                and => an_account_scraper_validation_failed(),
                and => persisting_an_account(),
                and => getting_the_total_accounts_persisted(),
                then => then_zero_accounts_should_be_persisted());
        }



    }
}