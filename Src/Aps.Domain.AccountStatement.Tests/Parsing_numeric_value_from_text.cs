using Aps.Domain.AccountStatements;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatement.Tests
{
    [TestClass]
    [FeatureDescription(@"Parse text data to numerical representation so that integrity checks can be performed.")]
    public partial class Parsing_numeric_value_from_text
    {
        [TestMethod]
        public void Parsing_a_numeric_value()
        {
            Runner.RunScenario(
                given => A_data_pair_with_value("150"),
                when => Parsing_the_data_pair(),
                then => The_returned_numeric_value_is(NumericValue.FromNumber(150)));
        }

        [TestMethod]
        public void Parsing_a_currency_value()
        {
            Runner.RunScenario(
                given => A_data_pair_with_value("R 150.50"),
                when => Parsing_the_data_pair(),
                then => The_returned_numeric_value_is(NumericValue.FromNumber(150.5)));
        }

        [TestMethod]
        public void Parsing_a_formatted_numeric_value()
        {
            Runner.RunScenario(
                given => A_data_pair_with_value("1,000,000.00"),
                when => Parsing_the_data_pair(),
                then => The_returned_numeric_value_is(NumericValue.FromNumber(1000000)));
        }

        [TestMethod]
        public void Parsing_a_negative_numeric_value_using_a_minus_sign_indicator()
        {
            Runner.RunScenario(
                given => A_data_pair_with_value("-100"),
                when => Parsing_the_data_pair(),
                then => The_returned_numeric_value_is(NumericValue.FromNumber(-100)));
        }

        [TestMethod]
        public void Parsing_a_negative_numeric_value_using_a_bracket_indicator()
        {
            Runner.RunScenario(
                given => A_data_pair_with_value("(100)"),
                when => Parsing_the_data_pair(),
                then => The_returned_numeric_value_is(NumericValue.FromNumber(-100)));
        }
    }
}
