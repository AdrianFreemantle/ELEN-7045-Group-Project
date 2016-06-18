using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    [TestClass]
    [FeatureDescription(@"A scraper script must be valid on creation")]
    public partial class Scraper_script_create
    {
        [TestMethod]
        public void a_scraper_script_must_be_valid_on_creation_given_a_valid_script()
        {
            Runner.RunScenario(
                given => a_script("a valid script"),
                when => creating_a_scraper_script(),
                then => the_scraper_is_valid()
                );
        }

        [TestMethod]
        public void a_scraper_script_must_be_invalid_on_creation_given_a_invalid_script()
        {
            Runner.RunScenario(
                given => a_script(string.Empty),
                when => creating_a_scraper_script(),
                then => the_scraper_is_invalid()
                );
        }
    }
}
