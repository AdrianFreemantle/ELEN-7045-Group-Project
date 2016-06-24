using System;
using Aps.Domain.Companies;
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
                and => a_company_type(CompanyType.TelcoServiceProvider),
                and => a_scraper_script(new ScraperScript("my custom script")),
                and => a_billing_cycle(new BillingCycle(new LeadTime(2), new NumberOfDaysPerCycle(CycleMethod.Monthly), new RetryInterval(3))),
                and => a_base_url(new BaseUrl("http://www.validuri.com")),
                and => a_company_factory(),
                when => creating_a_new_company(),
                then => a_valid_company_is_created()
                );
        }
    }
}
