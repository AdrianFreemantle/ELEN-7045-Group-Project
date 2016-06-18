using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatements.Tests
{
    [TestClass]
    [ScenarioCategory("Account Statements")]
    [FeatureDescription(@"As a customer I want to have all account statements to be presented in a consistent manner in order to prevent confusion when viewing account statements from different billing companies")]
    public partial class Consistent_representation_of_account_statements
    {
        [TestMethod]
        public void Test()
        {
            Assert.Inconclusive("Not Implemented");
        }
    }
}