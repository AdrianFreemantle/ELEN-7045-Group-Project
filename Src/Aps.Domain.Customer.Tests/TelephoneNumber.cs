using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Aps.Domain.Customer.Tests
{
    [TestClass]
    [Label("Telephone Number")]
    [FeatureDescription(@"A telephone number should be valid")]

    public partial class TelephoneNumber : FeatureFixture
    {
        [TestMethod]
        public void TestMethod2()
        {
            Runner.RunScenario(
                Given => a_telephone_number("011 456 7899"),
                when => creating_a_telephone_number_value_object(),
                then => Success());
        }


    }
}
