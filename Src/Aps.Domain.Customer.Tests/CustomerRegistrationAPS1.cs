using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Customer.Tests
{
    [TestClass]
    [Label("Customer APS Registration")]
    [FeatureDescription(@"Customer attemps to register with APS")]
    public partial class CustomerRegistration : FeatureFixture
    {
        [TestMethod]
        public void TestMethod1()
        {
            //resharper shortcut for method extraction is CTRL-R-M 
            Runner.RunScenario(
                Given => that_a_customer_enters_a_name("Bob"),
                And   => a_customer_enters_a_surname("Marley"),
                And   => a_customer_enters_email_address("bob@marley.com"),
                When  => the_users_pushes_the_register_button(),
                Then  => a_email_is_sent_to_confirm_the_registration());
        }

    }
}
