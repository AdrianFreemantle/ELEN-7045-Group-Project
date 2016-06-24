using Aps.Domain.Companies;
using LightBDD;
using Shouldly;

namespace Aps.Domain.Company.Tests
{
    public partial class BaseUrl_Identity : FeatureFixture
    {
        private BaseUrl _baseUrl1;
        private BaseUrl _baseUrl2;
        private bool _areEqual;

        private void a_base_url(BaseUrl first)
        {
            _baseUrl1 = first;
        }

        private void another_base_url(BaseUrl second)
        {
            _baseUrl2 = second;
        }

        private void performing_an_equality_comparison()
        {
            _areEqual = _baseUrl1.Equals(_baseUrl2);
        }

        private void the_two_are_equal()
        {
            _areEqual.ShouldBe(true);
        }

        private void the_two_are__not_equal()
        {
            _areEqual.ShouldBe(false);
        }
    }
}
