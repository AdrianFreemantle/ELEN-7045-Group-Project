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
    [Label("Customer Registration")]
    [FeatureDescription(@"Customer attemps to register")]
    public partial class CustomerRegistration : FeatureFixture
    {
        [TestMethod]
        public void TestMethod1()
        { 
            Runner.RunScenario(
                Given => that_a_customer_enters_email("man@moon.co.za"));
        }

      
    }
}