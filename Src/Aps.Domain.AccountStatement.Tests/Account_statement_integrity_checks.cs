using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatement.Tests
{
    [TestClass]
    [ScenarioCategory("Account Statements")]
    [FeatureDescription(@"As a customer I want the values on an account statement presented to me by APS to be consistent with the values on the account statement provided by my billing company")]
    public partial class Account_statement_integrity_checks
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