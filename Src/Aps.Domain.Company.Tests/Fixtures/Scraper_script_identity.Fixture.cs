using Aps.Domain.Companies;
using LightBDD;
using Shouldly;

namespace Aps.Domain.Company.Tests
{
    public partial class Scraper_script_identity : FeatureFixture
    {
        private ScraperScript _scraperScript1;
        private ScraperScript _scraperScript2;
        private bool _areEqual;

        private void a_scraper_script(ScraperScript first)
        {
            _scraperScript1 = first;
        }

        private void another_scraper_script(ScraperScript second)
        {
            _scraperScript2 = second;
        }

        private void performing_an_equality_comparison()
        {
            _areEqual = _scraperScript1.Equals(_scraperScript2);
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
