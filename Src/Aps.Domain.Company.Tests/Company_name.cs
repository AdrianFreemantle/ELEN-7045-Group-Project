using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    [TestClass]
    [FeatureDescription(@"A company name must be a valid name")]
    public partial class Company_name
    {
        [TestMethod]
        public void given_a_valid_name_when_creating_a_company_name_it_must_be_valid()
        {
            Runner.RunScenario(
                given => a_name("Company1"),
                when => creating_a_company_name(),
                then => create_a_valid_comapany_name()
                );
        }

        [TestMethod]
        public void given_an_invalid_name_when_creating_a_company_name_it_must_throw_an_error()
        {
            Runner.RunScenario(
                given => a_name(string.Empty),
                when => creating_a_company_name(),
                then => throw_error()
                );
        }
    }
}
