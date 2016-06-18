using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Customer.Tests
{
    [TestClass]
    [Label("Customer APS Registration")]
    [FeatureDescription(@"Customer attemps to register with APS")]
    public partial class CustomerRegistrationAPS : FeatureFixture
    {
        [TestMethod]
        public void TestMethod1()
        {
            //resharper shortcut for method extraction is CTRL-R-M 
            Runner.RunScenario(
                Given => that_a_customer_enters_a_name("Bob"),
                And => a_customer_enters_a_surname("Marley"),
                And => a_customer_enters_email_address("bob@marley.com"),
                When => the_users_pushes_the_register_button(),
                Then => a_email_is_sent_to_confirm_the_registration());
        }

        [TestMethod]
        public void TestMethod2()
        {
            Runner.RunScenario(
                Given => A_customer_has_received_a_valid_username("James"),
                And => A_cusotmer_has_receive_a_valid_password("g8keeper"),
                When => The_customer_attempts_to_login(),
                Then => The_customer_is_able_to_login());
        }

    }

}

