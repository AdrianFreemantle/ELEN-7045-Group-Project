using System;
using System.Globalization;
using Aps.Domain.Common;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Aps.Domain.AccountStatements.Tests
{
    [TestClass]
    [ScenarioCategory("Account Statements")]
    [FeatureDescription(@"As a customer I want to have all entry types presented in a consistent manner for all of my accounts in order to prevent confusion when viewing account statements from different billing companies")]
    public partial class Consistent_representation_of_entry_types
    {
        [TestMethod]
        public void A_scrape_result_data_pair_for_a_total_due_statement_field_is_converted_and_presented_correctly()
        {
            Runner.RunScenario(
            given => an_account_statement_entry_factory(),
            and => an_account_statment_entry_type(AccountStatmentEntryType.TotalDue),
            and => a_scrape_result_data_pair_with_id_and_description_and_value("001", "Total Amount Due", "1500"),
            when => building_an_account_statment_entry(),
            and => getting_the_account_statement_entry_display_value(),
            then => the_description_should_be_expected("Total Due"), 
            and => the_value_should_be_expected("R1,500.00"));
        }

        [TestMethod]
        public void A_scrape_result_data_pair_for_an_account_statement_number_statement_field_is_converted_and_presented_correctly()
        {
            Runner.RunScenario(
            given => an_account_statement_entry_factory(),
            and => an_account_statment_entry_type(AccountStatmentEntryType.StatementNumber),
            and => a_scrape_result_data_pair_with_id_and_description_and_value("001", "Stat. No", "1601-34567890"),
            when => building_an_account_statment_entry(),
            and => getting_the_account_statement_entry_display_value(),
            then => the_description_should_be_expected("Statement Number"),
            and => the_value_should_be_expected("1601-34567890"));
        }
    }
}