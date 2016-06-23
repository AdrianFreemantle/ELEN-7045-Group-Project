using System;
using Aps.Domain.Company.Tests.DomainTypes;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    public partial class Company_factory : FeatureFixture
    {
        private CompanyName _companyName;
        private CompanyFactory _companyFactory;
        private DomainTypes.Company _company;
        private CompanyType _companyType;
        private ScraperScript _scraperScript;
        private BillingCycle _billingCycle;
        private BaseUrl _baseUrl;
        private Exception error;

        private void a_company_name(CompanyName companyName)
        {
            _companyName = companyName;
        }

        private void a_company_factory()
        {
            _companyFactory = new CompanyFactory();
        }

        private void a_company_type(CompanyType companyType)
        {
            _companyType = companyType;
        }

        private void a_scraper_script(ScraperScript scraperScript)
        {
            _scraperScript = scraperScript;
        }

        private void a_billing_cycle(BillingCycle billingCycle)
        {
            _billingCycle = billingCycle;
        }

        private void creating_a_new_company()
        {
            try
            {
                _company = _companyFactory.CreateCompany(_companyName, _companyType, _scraperScript, _billingCycle, _baseUrl);
            }
            catch (Exception exception)
            {
                error = exception;
            }
        }

        private void a_valid_company_is_created()
        {
            Assert.IsNull(error);
        }

        private void a_base_url(BaseUrl baseUrl)
        {
            _baseUrl = baseUrl;
        }
    }
}
