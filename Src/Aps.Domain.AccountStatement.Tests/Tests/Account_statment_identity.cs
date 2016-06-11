﻿using Aps.Domain.AccountStatement.Tests.Tests.DomainTypes;
using Aps.Domain.AccountStatement.Tests.Tests.Stubs;
using Aps.Domain.AccountStatements;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatement.Tests.Tests
{
    [TestClass]
    [FeatureDescription(@"An account statement should be uniquely identifiable")]
    public partial class Account_statment_identity 
    {
        [TestMethod]
        public void Two_account_statement_identities_with_the_same_calendar_month_and_account_number_are_equal()
        {
            var first = AccountStatementId.Create(new AccountIdStub("12345"), new CalendarMonth(2015, 12));
            var second = AccountStatementId.Create(new AccountIdStub("12345"), new CalendarMonth(2015, 12));

            Runner.RunScenario(
            given => account_statement_id(first),
            and => another_account_statement_id(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_account_statement_identities_with_different_calendar_months_but_the_same_account_number_are_not_equal()
        {
            var first = AccountStatementId.Create(new AccountIdStub("12345"), new CalendarMonth(2016, 12));
            var second = AccountStatementId.Create(new AccountIdStub("12345"), new CalendarMonth(2015, 12));

            Runner.RunScenario(
            given => account_statement_id(first),
            and => another_account_statement_id(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }

        [TestMethod]
        public void Two_account_statement_identities_with_the_same_calendar_month_but_different_account_numbers_are_not_equal()
        {
            var first = AccountStatementId.Create(new AccountIdStub("12345"), new CalendarMonth(2015, 12));
            var second = AccountStatementId.Create(new AccountIdStub("45647"), new CalendarMonth(2015, 12));

            Runner.RunScenario(
            given => account_statement_id(first),
            and => another_account_statement_id(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
