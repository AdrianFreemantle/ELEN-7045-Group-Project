using System;
using System.Collections.Generic;
using Aps.Domain.AccountStatements;
using Aps.Domain.Common;
using Aps.Domain.Scraping;
using Aps.Domain.Services;
using Aps.Domain.Services.ScrapeSessionResultPipeline;
using APS.Domain.Services.Tests.Stubs;
using LightBDD;
using Moq;

// ReSharper disable once CheckNamespace
namespace APS.Domain.Services.Tests
{
    public partial class Scrape_result_pipeline : FeatureFixture
    {
        private readonly PipelineFactory<ScrapeSessionResult> scrapeSessionResultPipelineFactory = new PipelineFactory<ScrapeSessionResult>();
        private Mock<IAccountStatmentCreationService> mock;
        private ScrapeSessionResult scrapeSessionResult;
        private Pipeline<ScrapeSessionResult> pipeline;


        private void Then_the_account_statment_creation_service_creates_an_account_statement()
        {
            mock.Verify(service => service.CreateAccountStatementFromScrapeResult(scrapeSessionResult), () => Times.Exactly(1));
        }

        private void When_the_pipeline_is_invoked()
        {
            pipeline.Invoke(scrapeSessionResult);
        }

        private void And_a_scrape_session_result_pipeline_factory()
        {
            pipeline = scrapeSessionResultPipelineFactory.Build();
        }

        private void And_an_account_statment_creation_module()
        {
            scrapeSessionResultPipelineFactory.Register(new AccountStatmentCreationModule(mock.Object));
        }

        private void And_an_account_statment_creation_service()
        {
            mock = new Mock<IAccountStatmentCreationService>();
            mock.Setup(e => e.CreateAccountStatementFromScrapeResult(scrapeSessionResult));
        }

        private void Given_a_completed_scrape_session_result()
        {
            scrapeSessionResult = new ScrapeSessionResult(ScrapeSessionResultCode.Complete, new AccountIdStub("1234123"),
                DateTime.Now, new List<ScrapeResultDataPair>());
        }
    }
}
