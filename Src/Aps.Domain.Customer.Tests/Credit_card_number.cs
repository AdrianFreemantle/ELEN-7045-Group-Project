using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Customer.Tests
{
    [TestClass]
    [Label("Credit Card Number")]
    [FeatureDescription(@"A credit card number should be valid for payment purposes")]
    public partial class Credit_card_number : FeatureFixture
    {

      

        [TestMethod]
        public void TestMethod1()
        {
            //resharper shortcut for method extraction is CTRL-R-M 
            Runner.RunScenario(
                given => a_credit_card_number("1111222233334444"),
                when => creating_a_credit_card_number_value_object(),
                then => success());
        }

    }
}
