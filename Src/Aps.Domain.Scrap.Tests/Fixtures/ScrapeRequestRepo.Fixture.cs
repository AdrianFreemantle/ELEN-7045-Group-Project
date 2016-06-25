using System;
using System.Collections.Generic;
using System.Linq;
using Aps.Domain.Account;
using Aps.Domain.AccountStatements.Tests.Stubs;
using Aps.Domain.Scrap.Tests.Stubs;
using Aps.Domain.Common;
using Aps.Domain.Companies;
using Aps.Domain.Credential;
using Aps.Domain.Scrap.Tests.DomainTypes;
using Aps.Domain.Scraping;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Scrap.Tests
{
    public partial class ScrapeRequestRepo : FeatureFixture
    {
        private AccountId accountId;
        private ScrapeRequestFactory scrapeRequestFactory = new ScrapeRequestFactory();
        private ScrapeRequest scrapeRequest;
        private ScrapeRequestId scrapeRequestId;
        private Exception error;

        private ScrapeRequestRepositoryStub repository;


        private void a_valid_scrape_request()
        {
            ScrapeRequest_Id();
            account_id();
            scrapeRequest = scrapeRequestFactory.CreateScrapRequest(scrapeRequestId, accountId);
        }

        private void saving_the_scrap_request_data()
        {
            try
            {
                repository.Save(scrapeRequest);
            }
            catch (Exception e)
            {
                error = e;
            }
        }

        private void then_saved()
        {
            repository.saved.ShouldBe(true);
        }

        private void ScrapeRequest_Id()
        {
            scrapeRequestId = new ScrapeRequestId(Guid.NewGuid());
        }

        private void account_id()
        {

            accountId = new AccountId(new CompanyName("Edgars"), new AccountNumber("112345"));
        }

        private void an_scrap_request_repository()
        {
            repository = new ScrapeRequestRepositoryStub();
        }
    }
}