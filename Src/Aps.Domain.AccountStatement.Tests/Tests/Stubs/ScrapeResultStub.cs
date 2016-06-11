using System;
using System.Collections.Generic;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatement.Tests.Tests.Stubs
{
    public class ScrapeResultStub : IScrapeSessionResult
    {
        public IAccountId AccountId { get; private set; }
        public DateTime RunDateTime { get; private set; }
        public Uri BaseUri { get; private set; }
        public ICollection<TextValuePair> TextValuePairs { get; private set; }

        public ScrapeResultStub(IAccountId accountId, DateTime runDate)
            :this(accountId, runDate, new TextValuePair[0])
        {
        }

        public ScrapeResultStub(IAccountId accountId, DateTime runDate, ICollection<TextValuePair> textValuePairs)
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