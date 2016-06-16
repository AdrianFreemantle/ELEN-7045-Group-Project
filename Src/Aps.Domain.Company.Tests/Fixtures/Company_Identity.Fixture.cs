using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightBDD;
using Shouldly;

namespace Aps.Domain.Company.Tests
{
    public partial class Company_Identity : FeatureFixture
    {
        private CompanyName companyName1;
        private CompanyName companyName2;
        private bool areEqual;

        private void a_company_name(CompanyName first)
        {
            companyName1 = first;
        }

        private void another_company_name(CompanyName second)
        {
            companyName2 = second;
        }

        private void performing_an_equality_comparison()
        {
            areEqual = companyName1.Equals(companyName2);
        }

        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
