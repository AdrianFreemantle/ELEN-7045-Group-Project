using System;
using System.Collections.Generic;
using Aps.Domain.AccountStatements;

namespace Aps.Domain.Companies
{
    public class Company : IEquatable<Company>
    {
        private readonly List<IDataIntegrityCheck> integrityChecks;
        private readonly List<IDataIntegrityCheckOverride> integrityCheckOverrides;
        private readonly List<AccountStatementEntryMapping> mappings;

        public CompanyName CompanyName { get; private set; }
        public CompanyType CompanyType { get; private set; }
        public ScraperScript ScraperScript { get; private set; }
        public BillingCycle BillingCycle { get; private set; }
        public BaseUrl BaseUrl { get; private set; }

        public IEnumerable<IDataIntegrityCheck> IntegrityChecks
        {
            get { return integrityChecks; }
        }

        public IEnumerable<IDataIntegrityCheckOverride> IntegrityCheckOverrides
        {
            get { return integrityCheckOverrides; }
        }

        public IEnumerable<AccountStatementEntryMapping> Mappings
        {
            get { return mappings; }
        }


        protected Company()
        {
        }

        internal Company(CompanyName companyName, CompanyType companyType, ScraperScript scraperScript, BillingCycle billingCycle, BaseUrl baseUrl)
        {
            CompanyName = companyName;
            CompanyType = companyType;
            ScraperScript = scraperScript;
            BillingCycle = billingCycle;
            BaseUrl = baseUrl;

            integrityChecks = new List<IDataIntegrityCheck>();
            integrityCheckOverrides = new List<IDataIntegrityCheckOverride>();
            mappings = new List<AccountStatementEntryMapping>();
        }

        public bool Equals(Company other)
        {
            return CompanyName.Equals(other.CompanyName);
        }

        public void SetScriptAsBroken()
        {
            throw new NotImplementedException();
        }
    }
}
