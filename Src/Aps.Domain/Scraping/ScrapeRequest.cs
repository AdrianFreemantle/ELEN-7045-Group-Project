using System;
using Aps.Domain.Account;
using Aps.Domain.Companies;

namespace Aps.Domain.Scraping
{
    public class ScrapeRequest : IEquatable<ScrapeRequest>
    {
        private readonly ScrapeRequestId id;
        private readonly AccountId accountId;
        private ScrapeSessionResultCode scrapeSessionResultCode;
        private ScrapeDataAudit dataAudit;

        public AccountId AccountId
        {
            get { return accountId; }
        }

        protected ScrapeRequest()
        {
            
        }

        internal ScrapeRequest(ScrapeRequestId scrapeRequestId, AccountId accountId)
        {
            Guard.ThatValueTypeNotDefaut(scrapeRequestId, "scrapeRequestId");
            Guard.ThatValueTypeNotDefaut(accountId, "accountId");

            this.id = scrapeRequestId;
            this.accountId = accountId;
            this.scrapeSessionResultCode = ScrapeSessionResultCode.Pending;
        }

        public void Complete(ScrapeDataAudit dataAudit, ScrapeSessionResultCode resultCode)
        {
            Guard.ThatValueTypeNotDefaut(dataAudit, "dataAudit");
            Guard.ThatValueTypeNotDefaut(resultCode, "resultCode");

            this.dataAudit = dataAudit;
            this.scrapeSessionResultCode = resultCode;
        }

        public bool Equals(ScrapeRequest other)
        {
            return this.id.Equals(other.id);
        }

        //double dispatch
        public ScrapeSessionResult ExecuteScrape(IScraper scraper, IScraperScriptParser parser, Company company, Credentials credentials, IDecryptionService decrytpService)
        {
            //guards

            string xml = scraper.Execute(company.ScraperScript, company.BaseUrl, credentials.Securityfield, credentials.Identificationfield, decrytpService);
            dataAudit = new ScrapeDataAudit(xml);

            ScrapeSessionResult resultSet = parser.parse(xml, accountId);
            this.scrapeSessionResultCode = resultSet.ResultCode;
            return resultSet;
        }
    }
}