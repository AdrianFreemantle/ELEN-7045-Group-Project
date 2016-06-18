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
        private Exception error;

        private void a_company_name(CompanyName companyName)
        {
            _companyName = companyName;
        }

        private void a_company_factory()
        {
            _companyFactory = new CompanyFactory();
        }

        private void creating_a_new_company()
        {
            try
            {
                _company = _companyFactory.CreateCompany(_companyName);
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
