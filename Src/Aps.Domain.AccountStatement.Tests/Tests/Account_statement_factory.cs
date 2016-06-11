using System;
using System.IO.Pipes;
using Aps.Domain.AccountStatement.Tests.Tests.Stubs;
using Aps.Domain.AccountStatements;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatement.Tests.Tests
{
    [TestClass]
    [FeatureDescription(@"An account factory creates a valid instance of an account")]
    public partial class Account_statement_factory : FeatureFixture
    {
        //[TestMethod]
        //public void b()
        //{
        //    Runner.RunScenario(
        //        given => an_account_identity(new AccountIdStub("12345"))
        //        and => a_scrape_session_result())
        //}
    }
}