using Aps.Domain.Companies;
using LightBDD;
using Shouldly;

namespace Aps.Domain.Company.Tests
{
    public partial class Company_type_identity : FeatureFixture
    {
        private CompanyType _companyType1;
        private CompanyType _companyType2;
        private bool _areEqual;

        private void a_company_type(CompanyType first)
        {
            _companyType1 = first;
        }

        private void another_company_type(CompanyType second)
        {
            _companyType2 = second;
        }

        private void performing_an_equality_comparison()
        {
            _areEqual = _companyType1.Equals(_companyType2);
        }

        private void the_two_are_equal()
        {
            _areEqual.ShouldBe(true);
        }

        private void the_two_are_not_equal()
        {
            _areEqual.ShouldBe(false);
        }
    }
}
