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
        private static readonly DefaultFormatProviderSettings DefaultFomratProvider = new DefaultFormatProviderSettings();

        private AccountStatmentEntryType accountStatmentEntryType;
        private AccountStatmentEntryFactory accountStatmentEntryFactory;
        private ScrapeResultDataPair scrapeResultDataPair;
        private AccountStatmentEntry accountStatmentEntry;
        private string fieldId;
        private string fieldName;
        private string fieldValue;

        [TestMethod]
        public void An_account_statment_entry_for_a_total_due_statement_field_is_presented_correctly()
        {
            //todo: need test without checking against ToString, this is too fragile and will break if the string format changes
            string expectedValue = String.Format(DefaultFomratProvider.NumberFormat, "001 - {0} : {1:C}", AccountStatmentEntryType.TotalDue, 1500);

            accountStatmentEntryFactory = new AccountStatmentEntryFactory();
            accountStatmentEntryType = AccountStatmentEntryType.TotalDue;
            fieldId = "001";
            fieldName = "Total Amount Due";
            fieldValue = "R1500.00";
            scrapeResultDataPair = new ScrapeResultDataPair(fieldId, fieldName, fieldValue);
            accountStatmentEntry = accountStatmentEntryFactory.Build(accountStatmentEntryType, scrapeResultDataPair);
            accountStatmentEntry.ToString().ShouldBe(expectedValue);
        }

    }
}