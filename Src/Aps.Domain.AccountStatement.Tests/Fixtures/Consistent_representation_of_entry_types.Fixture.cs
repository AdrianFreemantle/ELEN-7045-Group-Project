using Aps.Domain.Common;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.AccountStatements.Tests
{
    public partial class Consistent_representation_of_entry_types : FeatureFixture
    {
        private static readonly DefaultFormatProviderSettings DefaultFomratProvider = new DefaultFormatProviderSettings();

        private AccountStatmentEntryType accountStatmentEntryType;
        private AccountStatmentEntryFactory accountStatmentEntryFactory;
        private ScrapeResultDataPair scrapeResultDataPair;
        private AccountStatmentEntry accountStatmentEntry;
        private AccountStatementEntryDisplayValue displayValue;

        private void and_the_value_should_be_expected(string expected)
        {
            this.displayValue.Value.ShouldBe(expected);
        }

        private void Then_the_description_should_be_expected(string expected)
        {
            displayValue.Description.ShouldBe(expected);
        }

        private void and_when_getting_the_account_statement_entry_display_value()
        {
            displayValue = accountStatmentEntry.GetDisplayValue();
        }

        private void when_building_an_account_statment_entry()
        {
            accountStatmentEntry = accountStatmentEntryFactory.Build(accountStatmentEntryType, scrapeResultDataPair);
        }

        private void and_given_scrape_result_data_pair_with_id_and_description_and_value(string id, string description, string value)
        {
            scrapeResultDataPair = new ScrapeResultDataPair(id, description, value);
        }

        private void and_given_account_statment_entry_type(AccountStatmentEntryType type)
        {
            accountStatmentEntryType = type;
        }

        private void given_an_account_statement_entry_factory()
        {
            accountStatmentEntryFactory = new AccountStatmentEntryFactory();
        }
    }
}