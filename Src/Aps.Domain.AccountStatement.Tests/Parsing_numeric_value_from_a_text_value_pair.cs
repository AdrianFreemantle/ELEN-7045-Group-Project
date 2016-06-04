using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Aps.Domain.AccountStatement.Tests
{
    [TestClass]
    [FeatureDescription(@"Parse text data to numerical representation so that integrity checks can be performed")]
    public partial class Parsing_numeric_value_from_a_text_value_pair
    {
        [TestMethod]
        public void Parsing_a_numeric_value()
        {
            Runner.RunScenario(
                given => A_data_pair_with_value("150"),
                when => Parsing_the_data_pair(),
                then => Decimal_value_returned_is(150));
        }

        [TestMethod]
        public void Parsing_a_currency_value()
        {
            Runner.RunScenario(
                given => A_data_pair_with_value("R 150.50"),
                when => Parsing_the_data_pair(),
                then => Decimal_value_returned_is(150.5M));
        }

        [TestMethod]
        public void Parsing_a_formatted_numeric_value()
        {
            Runner.RunScenario(
                given => A_data_pair_with_value("1,000,000.00"),
                when => Parsing_the_data_pair(),
                then => Decimal_value_returned_is(1000000M));
        }

        [TestMethod]
        public void Parsing_a_negative_numeric_value_using_a_minus_sign_indicator()
        {
            Runner.RunScenario(
                given => A_data_pair_with_value("-100"),
                when => Parsing_the_data_pair(),
                then => Decimal_value_returned_is(-100M));
        }

        [TestMethod]
        public void Parsing_a_negative_numeric_value_using_a_bracket_indicator()
        {
            Runner.RunScenario(
                given => A_data_pair_with_value("(100)"),
                when => Parsing_the_data_pair(),
                then => Decimal_value_returned_is(-100M));
        }
    }
}
