﻿using System;
using Aps.Domain.Account;
using Aps.Domain.Scrap;
using Aps.Domain.Common;
using Aps.Domain.Companies;
using Aps.Domain.Credential;
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
        private AccountId accountId;
        private ScrapeRequestFactory scrapeRequestFactory;
        private ScrapeRequest scrapeRequest;
        private ScrapeRequestId scrapeRequestId;
       
        private void ScrapeRequest_Id()
        {
           scrapeRequestId = new ScrapeRequestId(Guid.NewGuid());
        }

        private void account_id()
        {
            accountId = new AccountId(new CompanyName("Edgars"), new AccountNumber("112345"));
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
