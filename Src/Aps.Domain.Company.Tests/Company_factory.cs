using System;
using Aps.Domain.Company.Tests.DomainTypes;
using Aps.Domain.Company.Tests.Stubs;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    [TestClass]
    [FeatureDescription(@"A Company Factory creates a valid instance of a company")]
    public partial class Company_factory
    {
        [TestMethod]
        public void Creates_a_valid_company_from_a_company_name()
        {
            Runner.RunScenario(
                given => a_company_name(new CompanyName("Company1")),
                and => a_company_type(new CompanyTypeStub()),
                and => a_scraper_script(new ScraperScriptStub()),
                and => a_billing_cycle(new BillingCycleStub()),
                and => a_base_url(new BaseUrlStub()),
                and => a_company_factory(),
                when => creating_a_new_company(),
                then => a_valid_company_is_created()
                );
        }
    }
}
