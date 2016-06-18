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
    public partial class Company_name : FeatureFixture
    {
        private string _name;
        private CompanyName _companyName;
        private Exception _error;

        private void a_name(string company1)
        {
            _name = company1;
        }

        private void creating_a_company_name()
        {
            try
            {
                _companyName = new CompanyName(_name);
            }
            catch (Exception exception)
            {
                _error = exception;
            }
        }

        private void create_a_valid_comapany_name()
        {
            Assert.IsNull(_error);
        }

        private void throw_error()
        {
            Assert.IsNotNull(_error);
        }
    }
}
