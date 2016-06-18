using System;
using Aps.Domain.Company.Tests.DomainTypes;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    [TestClass]
    [FeatureDescription(@"A company type must be uniquely identifiable")]
    public partial class Company_type_identity
    {
        [TestMethod]
        public void Two_company_types_with_the_same_name_are_equal()
        {
            var first = CompanyType.TelcoServiceProvider;
            var second = CompanyType.TelcoServiceProvider;

            Runner.RunScenario(
                given => a_company_type(first),
                and => another_company_type(second),
                when => performing_an_equality_comparison(),
                then => the_two_are_equal()
                );
        }

        [TestMethod]
        public void Two_company_types_with_different_names_are_not_equal()
        {
            var first = CompanyType.TelcoServiceProvider;
            var second = CompanyType.CreditCardProvider;

            Runner.RunScenario(
                given => a_company_type(first),
                and => another_company_type(second),
                when => performing_an_equality_comparison(),
                then => the_two_are_not_equal()
                );
        }
    }
}
