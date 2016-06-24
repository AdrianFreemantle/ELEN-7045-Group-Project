using Aps.Domain.AccountStatements.Tests.Stubs;
using Aps.Domain.Common;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatements.Tests
{
    [TestClass]
    [ScenarioCategory("Account Statements")]
    [FeatureDescription(@"As a customer I want the values on an account statement presented to me by APS to be consistent with the values on the account statement provided by my billing company")]
    public partial class Account_statement_integrity_checks
    {
        [TestMethod]
        public void Addition_checking_with_valid_data()
        {
            Runner.RunScenario(
                given => a_successfull_scrape_session_for_account_id(new AccountIdStub("12345")),
                and => a_mapping_code_id_for_entryType("001", StatmentEntryType.OpeningBalance),
                and => a_mapping_code_id_for_entryType("002", StatmentEntryType.PaymentReceived),
                and => a_mapping_code_id_for_entryType("003", StatmentEntryType.NewCharges),
                and => a_mapping_code_id_for_entryType("004", StatmentEntryType.Discount),
                and => a_mapping_code_id_for_entryType("005", StatmentEntryType.Deductions),
                and => a_mapping_code_id_for_entryType("006", StatmentEntryType.TotalDue), 
                and => a_scrape_result_data_pair_with_id_and_description_and_value("001", "Opening Balance", "R 500.00"),
                and => a_scrape_result_data_pair_with_id_and_description_and_value("002", "Payment Received", "R 500.00"),
                and => a_scrape_result_data_pair_with_id_and_description_and_value("003", "New Charges", "R 200.00"),
                and => a_scrape_result_data_pair_with_id_and_description_and_value("004", "Discount", "R 20.00"),
                and => a_scrape_result_data_pair_with_id_and_description_and_value("005", "Deductions", "R 20.00"),
                and => a_scrape_result_data_pair_with_id_and_description_and_value("006", "Total Due", "R 160.00"),
                when => creating_an_account_statment(),
                then => Integrity_check_passed());
        }

        [TestMethod]
        public void Addition_checking_with_invalid_data()
        {
            Runner.RunScenario(
                given => a_successfull_scrape_session_for_account_id(new AccountIdStub("12345")),
                and => a_mapping_code_id_for_entryType("001", StatmentEntryType.OpeningBalance),
                and => a_mapping_code_id_for_entryType("002", StatmentEntryType.PaymentReceived),
                and => a_mapping_code_id_for_entryType("003", StatmentEntryType.NewCharges),
                and => a_mapping_code_id_for_entryType("004", StatmentEntryType.Discount),
                and => a_mapping_code_id_for_entryType("005", StatmentEntryType.Deductions),
                and => a_mapping_code_id_for_entryType("006", StatmentEntryType.TotalDue),
                and => a_scrape_result_data_pair_with_id_and_description_and_value("001", "Opening Balance", "R 9000000.00"),
                and => a_scrape_result_data_pair_with_id_and_description_and_value("002", "Payment Received", "R 500.00"),
                and => a_scrape_result_data_pair_with_id_and_description_and_value("003", "New Charges", "R 200.00"),
                and => a_scrape_result_data_pair_with_id_and_description_and_value("004", "Discount", "R 20.00"),
                and => a_scrape_result_data_pair_with_id_and_description_and_value("005", "Deductions", "R 20.00"),
                and => a_scrape_result_data_pair_with_id_and_description_and_value("006", "Total Due", "R 160.00"),
                when => creating_an_account_statment(),
                then => Integrity_check_failed());
        }
    }
}