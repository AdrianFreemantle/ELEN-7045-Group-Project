using Aps.Domain.Common;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.AccountStatements.Tests
{
    public partial class Consistent_representation_of_entry_types : FeatureFixture
    {
        private AccountStatmentEntryType accountStatmentEntryType;
        private AccountStatmentEntryFactory accountStatmentEntryFactory;
        private ScrapeResultDataPair scrapeResultDataPair;
        private AccountStatmentEntry accountStatmentEntry;
        private AccountStatementEntryDisplayValue displayValue;

        private void the_value_should_be_expected(string expected)
        {
            this.displayValue.Value.ShouldBe(expected);
        }

        private void the_description_should_be_expected(string expected)
        {
            displayValue.Description.ShouldBe(expected);
        }

        private void getting_the_account_statement_entry_display_value()
        {
            displayValue = accountStatmentEntry.GetDisplayValue();
        }

        private void building_an_account_statment_entry()
        {
            accountStatmentEntry = accountStatmentEntryFactory.Build(accountStatmentEntryType, scrapeResultDataPair);
        }

        private void a_scrape_result_data_pair_with_id_and_description_and_value(string id, string description, string value)
        {
            scrapeResultDataPair = new ScrapeResultDataPair(id, description, value);
        }

        private void an_account_statment_entry_type(AccountStatmentEntryType type)
        {
            accountStatmentEntryType = type;
        }

        private void an_account_statement_entry_factory()
        {
            accountStatmentEntryFactory = new AccountStatmentEntryFactory();
        }
    }
}