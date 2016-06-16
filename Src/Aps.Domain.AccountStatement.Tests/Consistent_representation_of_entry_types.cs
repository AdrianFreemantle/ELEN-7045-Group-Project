using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatements.Tests
{
    [TestClass]
    [ScenarioCategory("Account Statements")]
    [FeatureDescription(@"As a customer I want to have all entry types presented in a consistent manner for all of my accounts in order to prevent confusion when viewing account statements from different billing companies")]
    public partial class Consistent_representation_of_entry_types
    {
        [TestMethod]
        public void Test()
        {
            Runner.RunScenario(NotImplemented);
        }

        private static void NotImplemented()
        {
            throw new NotImplementedException();
        }
    }
}