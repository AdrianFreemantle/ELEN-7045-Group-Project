using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatement.Tests.Tests
{
    [TestClass]
    [FeatureDescription(@"Account statments should be equatable based on identity and not on internal state")]
    public partial class Account_statement_equality : FeatureFixture 
    {
        [TestMethod]
        public void Two_account_statement_with_the_same_identities_are_equal()
        {
            throw new NotImplementedException();
            //Runner.RunScenario(
            //given => account_statement_with_identity(first),
            //and => another_account_statement_with_identity(second),
            //when => performing_an_equality_comparison(),
            //then => the_two_statements_are_equal());
        }
    }
}