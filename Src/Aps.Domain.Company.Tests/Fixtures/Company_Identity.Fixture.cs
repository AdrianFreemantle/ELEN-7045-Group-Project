using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Company.Tests.DomainTypes;
using Aps.Domain.Company.Tests.Stubs;
using LightBDD;
using Shouldly;

namespace Aps.Domain.Company.Tests
{
    public partial class Company_Identity : FeatureFixture
    {
        private readonly CompanyFactory _companyFactory = new CompanyFactory();
        private DomainTypes.Company _company1;
        private DomainTypes.Company _company2;
        private bool areEqual;

        private void a_company(string company1Name)
        {
            var companyTypeStub = new CompanyTypeStub();
            var scraperScriptStub = new ScraperScriptStub();
            var billingCycleStub = new BillingCycleStub();
            _company1 = _companyFactory.CreateCompany(new CompanyName(company1Name), companyTypeStub, scraperScriptStub, billingCycleStub);
        }

        private void another_company(string company2Name)
        {
            var companyTypeStub = new CompanyTypeStub();
            var scraperScriptStub = new ScraperScriptStub();
            var billingCycleStub = new BillingCycleStub();
            _company2 = _companyFactory.CreateCompany(new CompanyName(company2Name), companyTypeStub, scraperScriptStub, billingCycleStub);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = _company1.Equals(_company2);
        }

        private void the_companies_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void the_companies_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
