using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatement.Tests
{
    [TestClass]
    [ScenarioCategory("Account Statements")]
    [FeatureDescription(@"As a customer I want a have consolodated view of my account statements so that I can understand my current financial situation.")]
    public partial class Aggregated_account_statements
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