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
            var first = new CompanyName("Company1");
            var second = new CompanyName("Company1");
            
            Runner.RunScenario(
                given => a_company_name(first),
                and => another_company_name(second),
                when => performing_an_equality_comparison(),
                then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_companies_with_different_names_are_not_equal()
        {
            
        }
    }

    public struct CompanyName : IEquatable<CompanyName>
    {
        public string Name { get; private set; }

        public CompanyName(string name)
        {
            this.Name = name;
        }

        public bool Equals(CompanyName other)
        {
            return Name.Equals(other.Name);
        }
    }
}
