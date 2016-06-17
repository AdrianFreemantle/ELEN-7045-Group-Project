using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Aps.Domain.Customer.Tests
{
    [TestClass]
    [Label("CCV Number")]
    [FeatureDescription(@"A CCV number should be valid for payment purposes")]

    public partial class Ccv_Number : FeatureFixture
    {
        [TestMethod]
        public void TestMethod2()
        {
            Runner.RunScenario(
                Given => a_ccv_number("123"),
                when => creating_a_ccv_number_value_object(),
                then => Success());
        }
    }
}
