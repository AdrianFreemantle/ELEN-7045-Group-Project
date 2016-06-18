using System;
using Aps.Domain.Company.Tests.DomainTypes;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    [TestClass]
    [FeatureDescription(@"A scraper script must be uniquely identifiable")]
    public partial class Scraper_script_identity
    {
        [TestMethod]
        public void two_scraper_scripts_with_the_same_script_are_equal()
        {
            var first = new ScraperScript("test script1");
            var second = new ScraperScript("test script1");

            Runner.RunScenario(
                given => a_scraper_script(first),
                and => another_scraper_script(second),
                when => performing_an_equality_comparison(),
                then => the_two_are_equal()
                );
        }

        [TestMethod]
        public void two_scraper_scripts_with_a_different_script_are_not_equal()
        {
            var first = new ScraperScript("test script1");
            var second = new ScraperScript("test script2");

            Runner.RunScenario(
                given => a_scraper_script(first),
                and => another_scraper_script(second),
                when => performing_an_equality_comparison(),
                then => the_two_are_not_equal()
                );
        }
    }
}
