using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    [TestClass]
    [FeatureDescription(@"A company must be uniquely identifiable")]
    public partial class Company_Identity
    {
        [TestMethod]
        public void Two_companies_with_the_same_name_are_equal()
        {
            Runner.RunScenario(
                given => a_company("Company1"),
                and => another_company("Company1"),
                when => performing_an_equality_comparison(),
                then => the_companies_are_equal()
                );
        }

        [TestMethod]
        public void Two_companies_with_different_names_are_not_equal()
        {
            Runner.RunScenario(
                given => a_company("Company1"),
                and => another_company("Company2"),
                when => performing_an_equality_comparison(),
                then => the_companies_are_not_equal()
                );
        }
    }
}
