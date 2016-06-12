using Aps.Domain.Account;
using Aps.Domain.Account.Tests.DomainTypes;
using Aps.Domain.Account.Tests.Stubs;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Account.Tests
{
    [TestClass]
    [FeatureDescription(@"An account should be uniquely identifiable")]
    public partial class Account_identity
    {
        [TestMethod]
        public void Two_account_identities_with_the_same_company_name_and_account_number_are_equal()
        {
            var first = AccountId.Create(new CompanyNameStub("Acme Ltd"), new AccountNumber("1234567890"));
            var second = AccountId.Create(new CompanyNameStub("Acme Ltd"), new AccountNumber("1234567890"));

            Runner.RunScenario(
            given => account_id(first),
            and => another_account_id(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_account_identities_with_diferent_company_name_and_account_number_are_not_equal()
        {
            var first = AccountId.Create(new CompanyNameStub("Acme Ltd"), new AccountNumber("1234567890"));
            var second = AccountId.Create(new CompanyNameStub("JCSE Ltd"), new AccountNumber("1234567890"));

            Runner.RunScenario(
            given => account_id(first),
            and => another_account_id(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }

        [TestMethod]
        public void Two_account_identities_with_the_same_company_name_but_different_account_numbers_are_not_equal()
        {
            var first = AccountId.Create(new CompanyNameStub("Acme Ltd"), new AccountNumber("1234567890"));
            var second = AccountId.Create(new CompanyNameStub("Acme Ltd"), new AccountNumber("0987654321"));

            Runner.RunScenario(
            given => account_id(first),
            and => another_account_id(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
