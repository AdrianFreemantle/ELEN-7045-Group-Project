using System;
using System.Globalization;
using Aps.Domain.Common;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Aps.Domain.AccountStatements.Tests
{
    [TestClass]
    [ScenarioCategory("Account Statement Entries")]
    [FeatureDescription(@"As a customer I want to have all entry types presented in a consistent manner for all of my accounts in order to prevent confusion when viewing account statements from different billing companies")]
    public partial class Consistent_representation_of_entry_types
    {
        [TestMethod]
        public void A_scrape_result_data_pair_for_a_total_due_statement_field_is_converted_and_presented_correctly()
        {
            Runner.RunScenario(
            given => an_account_statement_entry_factory(),
            and => an_account_statement_entry_type(StatementEntryType.TotalDue),
            and => a_scrape_result_data_pair_with_id_and_description_and_value("001", "Total Amount Due", "1500"),
            when => building_an_account_statement_entry(),
            and => getting_the_account_statement_entry_display_value(),
            then => the_description_should_be_expected("Total Due"), 
            and => the_value_should_be_expected("R1,500.00"));
        }
        [TestMethod]
        public void A_scrape_result_data_pair_for_an_account_statement_number_statement_field_is_converted_and_presented_correctly()
        {
            Runner.RunScenario(
            given => an_account_statement_entry_factory(),
            and => an_account_statement_entry_type(StatementEntryType.StatementNumber),
            and => a_scrape_result_data_pair_with_id_and_description_and_value("001", "Stat. No", "1601-34567890"),
            when => building_an_account_statement_entry(),
            and => getting_the_account_statement_entry_display_value(),
            then => the_description_should_be_expected("Statement Number"),
            and => the_value_should_be_expected("1601-34567890"));
        }

        [TestMethod]
        public void A_scrape_result_data_pair_for_an_electricity_used_statement_field_is_converted_and_presented_correctly()
        {
            Runner.RunScenario(
            given => an_account_statement_entry_factory(),
            and => an_account_statement_entry_type(StatementEntryType.ElectricityUsed),
            and => a_scrape_result_data_pair_with_id_and_description_and_value("001", "Elec. Use", "567kwh"),
            when => building_an_account_statement_entry(),
            and => getting_the_account_statement_entry_display_value(),
            then => the_description_should_be_expected("Electricity Used"),
            and => the_value_should_be_expected("567 kWh"));
        }

        [TestMethod]
        public void A_scrape_result_data_pair_for_an_interest_rate_field_is_converted_and_presented_correctly()
        {
            Runner.RunScenario(
            given => an_account_statement_entry_factory(),
            and => an_account_statement_entry_type(StatementEntryType.InterestRate),
            and => a_scrape_result_data_pair_with_id_and_description_and_value("001", "Interest Rt.", "12"),
            when => building_an_account_statement_entry(),
            and => getting_the_account_statement_entry_display_value(),
            then => the_description_should_be_expected("Interest Rate"),
            and => the_value_should_be_expected("12.0 %"));
        }

        [TestMethod]
        public void A_scrape_result_data_pair_for_a_total_call_duration_field_is_converted_and_presented_correctly()
        {
            Runner.RunScenario(
            given => an_account_statement_entry_factory(),
            and => an_account_statement_entry_type(StatementEntryType.TotalCallDuration),
            and => a_scrape_result_data_pair_with_id_and_description_and_value("001", "Call Length", "00:12:25"),
            when => building_an_account_statement_entry(),
            and => getting_the_account_statement_entry_display_value(),
            then => the_description_should_be_expected("Total Call Duration"),
            and => the_value_should_be_expected("00:12:25"));
        }

        [TestMethod]
        public void A_scrape_result_data_pair_for_a_due_date_field_is_converted_and_presented_correctly()
        {
            Runner.RunScenario(
            given => an_account_statement_entry_factory(),
            and => an_account_statement_entry_type(StatementEntryType.DueDate),
            and => a_scrape_result_data_pair_with_id_and_description_and_value("001", "Due by", "2016-01-31"),
            when => building_an_account_statement_entry(),
            and => getting_the_account_statement_entry_display_value(),
            then => the_description_should_be_expected("Due Date"),
            and => the_value_should_be_expected(new DateTime(2016, 01, 31).ToShortDateString()));
        }

        [TestMethod]
        public void A_scrape_result_data_pair_for_a_statement_month_field_is_converted_and_presented_correctly()
        {
            Runner.RunScenario(
            given => an_account_statement_entry_factory(),
            and => an_account_statement_entry_type(StatementEntryType.StatementMonth),
            and => a_scrape_result_data_pair_with_id_and_description_and_value("001", "Month", "03"),
            when => building_an_account_statement_entry(),
            and => getting_the_account_statement_entry_display_value(),
            then => the_description_should_be_expected("Statement Month"),
            and => the_value_should_be_expected("Mar"));
        }
    }
}