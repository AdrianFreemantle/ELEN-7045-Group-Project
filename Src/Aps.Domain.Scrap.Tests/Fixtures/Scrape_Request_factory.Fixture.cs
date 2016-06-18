using System;
using Aps.Domain.Scrap;
using Aps.Domain.Common;
using Aps.Domain.Scrap.Tests.DomainTypes;
using Aps.Domain.Scraping;
using LightBDD;
using Shouldly;
using AccountIdStub = Aps.Domain.AccountStatements.Tests.Stubs.AccountIdStub;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Scrap.Tests
{
    public partial class Scrape_Request_Factory : FeatureFixture
    {

        private AccountIdStub accountId;
        private ScrapeResultStub scrapeSessionResult;
        private ScrapeRequestFactory scrapeRequestFactory;
        private ScrapeRequest scrapeRequest;
        private ScrapeRequestId scrapeRequestId;
        public ICompanyName Edgars { get; private set; }

        private void ScrapeRequest_Id()
        {
           scrapeRequestId = new ScrapeRequestId(Guid.NewGuid());
        }

        private void account_id()
        {
            accountId = new AccountIdStub("112345", Edgars);
        }

        private void an_scrape_request_factory()
        {
            scrapeRequestFactory = new ScrapeRequestFactory();
        }

        private void creating_an_scrape_request()
        {
            scrapeRequest = scrapeRequestFactory.CreateScrapRequest(scrapeRequestId, accountId);
        }

        private void a_valid_scrap_request_is_created()
        {
            var myStatements = scrapeRequestFactory.CreateScrapRequest(scrapeRequestId, accountId);
            scrapeRequest.Equals(myStatements).ShouldBe(true);

            
        }
    }
}
