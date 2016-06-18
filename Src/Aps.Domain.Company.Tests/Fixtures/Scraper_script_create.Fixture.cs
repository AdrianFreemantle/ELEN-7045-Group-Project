using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Company.Tests.DomainTypes;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    public partial class Scraper_script_create : FeatureFixture
    {
        private string _script;
        private ScraperScript _scraperScript;
        private Exception _error;

        private void a_script(string script)
        {
            _script = script;
        }

        private void creating_a_scraper_script()
        {
            try
            {
                _scraperScript = new ScraperScript(_script);
            }
            catch (Exception exception)
            {
                _error = exception;
            }
        }

        private void the_scraper_is_valid()
        {
            Assert.IsNull(_error);
        }

        private void the_scraper_is_invalid()
        {
            Assert.IsNotNull(_error);
        }
    }
}
