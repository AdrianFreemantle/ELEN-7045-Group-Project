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
        public void Parsing_a_valid_numeric_value_from_a_data_pair()
        {
            Runner.RunScenario(
                Given_a_data_pair_that_maps_to_a_numeric_value,
                When_parsing_the_data_pair,
                Then_a_valid_decimal_value_is_returned);
        }
    }
}
