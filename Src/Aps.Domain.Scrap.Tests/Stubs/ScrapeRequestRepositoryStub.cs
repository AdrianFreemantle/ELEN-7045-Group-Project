using System;
using System.Collections.Generic;
using System.Linq;
using Aps.Domain.Scraping;

namespace Aps.Domain.Scrap.Tests.Stubs
{
    public class ScrapeRequestRepositoryStub : IScrapeRequestRepository
    {
        public bool saved;

        public void Save(ScrapeRequest scrapeRequest)
        {
            Guard.ThatParameterNotNull(scrapeRequest, "scrapeRequest");
            saved = true;
        }

        public ScrapeRequest fetchById(ScrapeRequestId Id)
        {
            throw new NotImplementedException();
        }

        public ScrapeRequest fetchNextPendingRequestForAccount(IAccountId accountId)
        {
            throw new NotImplementedException();
        }
    }
}