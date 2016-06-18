using System;
using Aps.Domain.Company.Tests.DomainTypes;
using Aps.Domain.Company.Tests.Stubs;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    public partial class Company_factory : FeatureFixture
    {
        private CompanyName _companyName;
        private CompanyFactory _companyFactory;
        private DomainTypes.Company _company;
        private CompanyTypeStub _companyTypeStub;
        private ScraperScriptStub _scraperScriptStub;
        private BillingCycleStub _billingCycleStub;
        private Exception error;

        private void a_company_name(CompanyName companyName)
        {
            _companyName = companyName;
        }

        private void a_company_factory()
        {
            _companyFactory = new CompanyFactory();
        }

        private void a_company_type(CompanyTypeStub companyTypeStub)
        {
            _companyTypeStub = companyTypeStub;
        }

        private void a_scraper_script(ScraperScriptStub scraperScriptStub)
        {
            _scraperScriptStub = scraperScriptStub;
        }

        private void a_billing_cycle(BillingCycleStub billingCycleStub)
        {
            _billingCycleStub = billingCycleStub;
        }

        private void creating_a_new_company()
        {
            try
            {
                _company = _companyFactory.CreateCompany(_companyName, _companyTypeStub, _scraperScriptStub, _billingCycleStub);
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
    }
}
