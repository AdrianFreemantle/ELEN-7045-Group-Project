using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Company.Tests.Stubs;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public class CompanyFactory : ICompanyFactory
    {
        public Company CreateCompany(CompanyName companyName)
        {
            return new Company(companyName);
        }

        public Company CreateCompany(CompanyName companyName, ICompanyType companyType, IScraperScript scraperScript, IBillingCycle billingCycle)
        {
            return new Company(companyName);
        }
    }

    public interface ICompanyFactory
    {
        Company CreateCompany(CompanyName companyName, ICompanyType companyType, IScraperScript scraperScript, IBillingCycle billingCycle);
    }
}
