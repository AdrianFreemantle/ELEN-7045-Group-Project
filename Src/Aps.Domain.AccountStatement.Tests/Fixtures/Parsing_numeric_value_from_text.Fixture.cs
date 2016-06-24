using Aps.Domain.AccountStatements;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.AccountStatements.Tests
{
    public partial class Parsing_numeric_value_from_text : FeatureFixture
    {
        private string valueToParse;
        private NumericValue parseResult;

        private void A_data_pair_with_value(string value)
        {
            valueToParse = value;
        }

        private void Parsing_the_data_pair()
        {
            parseResult = NumericValue.Parse(valueToParse);
        }

        private void The_returned_numeric_value_is(NumericValue result)
        {
            parseResult.ShouldBe(result);
        }
    }
}
