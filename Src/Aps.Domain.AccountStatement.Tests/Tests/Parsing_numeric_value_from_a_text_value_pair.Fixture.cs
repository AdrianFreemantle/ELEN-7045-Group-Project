using Aps.Domain.Common;
using Aps.Domain.Services;
using LightBDD;
using Shouldly;

namespace Aps.Domain.AccountStatement.Tests.Tests
{
    public partial class Parsing_numeric_value_from_a_text_value_pair : FeatureFixture
    {
        private TextValuePair valuePair;
        private decimal parseResult;

        private void A_data_pair_with_value(string value)
        {
            valuePair = new TextValuePair("Balance", value);
        }

        private void Parsing_the_data_pair()
        {
            var parser = new NumericValueParser();
            parseResult = parser.Parse(valuePair);
        }

        private void The_returned_numeric_value_is(decimal result)
        {
            parseResult.ShouldBe(result);
        }
    }
}
