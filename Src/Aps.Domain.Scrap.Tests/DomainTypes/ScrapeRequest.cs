using System;

namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    public class ScrapeRequest : IEquatable<ScrapeRequest>
    {

        private readonly ScrapeRequestId ID;
        private readonly IAccountId accountId;
        private ScrapeSessionResultCode scrapeSessionResultCode;
        private ScrapeDataAudit dataAudit;

        protected ScrapeRequest()
        {
            
        }

        internal ScrapeRequest(ScrapeRequestId scrapeRequestId, IAccountId accountId)
        {
            Guard.ThatValueTypeNotDefaut(scrapeRequestId, "scrapeRequestId");
            Guard.ThatValueTypeNotDefaut(accountId, "accountId");

            this.ID = scrapeRequestId;
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
            return this.ID.Equals(other.ID);
        }
    }
}