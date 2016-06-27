using System;
using System.Collections.Generic;
using Aps.Application.Tests.Stubs;
using Aps.Domain.Account;
using Aps.Domain.AccountStatements;
using Aps.Domain.Common;
using Aps.Domain.Companies;
using Aps.Domain.Notifications;
using Aps.Domain.Scraping;
using LightBDD;
using Moq;

// ReSharper disable once CheckNamespace
namespace Aps.Application.Tests
{
    public partial class Account_statement_creation_pipeline_module : FeatureFixture
    {
        private readonly PipelineFactory<ScrapeSessionResult> scrapeSessionResultPipelineFactory = new PipelineFactory<ScrapeSessionResult>();
        private Mock<IAccountStatementCreationService> accountStatementCreationServiceMock;
        private Mock<INotificationService> customerNotificationServiceMock;
        private Mock<IAccountStatusUpdateService> accountStatusUpdateServiceMock;
        private Mock<ICompanyScriptService> companyScriptServiceMock;
        private ScrapeSessionResult scrapeSessionResult;
        private Pipeline<ScrapeSessionResult> pipeline;

        private void And_a_customer_notification_service()
        {
            customerNotificationServiceMock = new Mock<INotificationService>();
            customerNotificationServiceMock.Setup(e => e.NotifyCustomerOfInvalidCredentialsForAccount(scrapeSessionResult.AccountId));
        }

        private void And_an_account_status_update_service()
        {
            accountStatusUpdateServiceMock = new Mock<IAccountStatusUpdateService>();
            accountStatusUpdateServiceMock.Setup(e => e.ActivateAccount(scrapeSessionResult.AccountId));
        }

        private void And_a_company_script_service()
        {
            companyScriptServiceMock = new Mock<ICompanyScriptService>();
            companyScriptServiceMock.Setup(e => e.SetScriptAsBroken(scrapeSessionResult.AccountId.CompanyName));
        }

        private void And_the_company_script_service_does_not_set_the_script_as_broken()
        {
            companyScriptServiceMock.Verify(service => service.SetScriptAsBroken(scrapeSessionResult.AccountId.CompanyName), Times.Never);
        }

        private void And_the_customer_notification_service_does_not_notify_the_customer()
        {
            customerNotificationServiceMock.Verify(service => service.NotifyCustomerOfInvalidCredentialsForAccount(scrapeSessionResult.AccountId), Times.Never);
        }

        private void And_the_account_status_service_activates_an_inactive_account()
        {
            accountStatusUpdateServiceMock.Verify(service => service.ActivateAccount(scrapeSessionResult.AccountId), () => Times.Exactly(1));
        }

        private void Then_the_account_statement_creation_service_creates_an_account_statement()
        {
            accountStatementCreationServiceMock.Verify(service => service.CreateAccountStatementFromScrapeResult(scrapeSessionResult), () => Times.Exactly(1));
        }

        private void When_the_pipeline_is_invoked()
        {
            pipeline.Invoke(scrapeSessionResult);
        }

        private void And_an_scrape_session_result_pipeline()
        {
            scrapeSessionResultPipelineFactory.Register(new AccountStatementCreationModule(accountStatementCreationServiceMock.Object));
            scrapeSessionResultPipelineFactory.Register(new AccountStatusUpdateModule(accountStatusUpdateServiceMock.Object));
            scrapeSessionResultPipelineFactory.Register(new BrokenScriptModule(companyScriptServiceMock.Object));
            scrapeSessionResultPipelineFactory.Register(new CustomerNotificationModule(customerNotificationServiceMock.Object));
            pipeline = scrapeSessionResultPipelineFactory.Build();
        }

        private void And_an_account_statement_creation_service()
        {
            accountStatementCreationServiceMock = new Mock<IAccountStatementCreationService>();
            accountStatementCreationServiceMock.Setup(e => e.CreateAccountStatementFromScrapeResult(scrapeSessionResult));
        }

        private void Given_a_completed_scrape_session_result()
        {
            scrapeSessionResult = new ScrapeSessionResult(ScrapeSessionResultCode.Complete, new AccountIdStub("1234123"),
                DateTime.Now, new List<ScrapeResultDataPair>());
        }
    }
}
