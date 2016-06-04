using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Aps.Domain.AccountStatement.Tests
{
    [TestClass]
    [Label("Parser-1")]
    [FeatureDescription(@"Parse text data to numerical representation so that integrity checks can be performed")]
    public partial class Parsing_numeric_data_field
    {
        [TestMethod]
        public void Parsing_a_currency_value_from_a_data_pair()
        {
            Runner.RunScenario(
                given => A_data_pair_with_value("R 150.50"),
                when => Parsing_the_data_pair(),
                then => Decimal_value_returned_is(150.5M));
        }
    }
}
