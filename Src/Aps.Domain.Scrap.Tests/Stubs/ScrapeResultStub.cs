using System;
using System.Collections.Generic;
using Aps.Domain.Common;

namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    public class ScrapeResultStub : IScrapeSessionResult
    {
        public IScrapeSessionResultCode ResultCode { get; private set; }
        public IAccountId AccountId { get; private set; }
        public DateTime RunDateTime { get; private set; }
        public Uri BaseUri { get; private set; }
        public ICollection<ScrapeResultDataPair> TextValuePairs { get; private set; }

        public ScrapeResultStub(IAccountId accountId, DateTime runDate)
            :this(accountId, runDate, new ScrapeResultDataPair[0])
        {
        }

        public ScrapeResultStub(IAccountId accountId, DateTime runDate, ICollection<ScrapeResultDataPair> textValuePairs)
        {
            AccountId = accountId;
            RunDateTime = runDate;
            TextValuePairs = textValuePairs;
            BaseUri = new Uri("http://localhost:8080");
        }

        public override string ToString()
        {
            return String.Format("Scrape result for account id {0}", AccountId);
        }
    }
}