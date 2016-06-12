using System;
using Aps.Domain.AccountStatement.Tests.DomainTypes;
using Aps.Domain.AccountStatement.Tests.Stubs;
using Aps.Domain.AccountStatements;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.AccountStatement.Tests
{
    public partial class Account_statement_factory : FeatureFixture
    {
        private AccountIdStub accountId;
        private ScrapeResultStub scrapeSessionResult;
        private AccountStatementFactory accountStatementFactory;
        private DomainTypes.AccountStatement accountStatement;

        private void a_valid_account_statement_is_created()
        {
            var accountStatementId = AccountStatementId.Create(accountId, new CalendarMonth(scrapeSessionResult.RunDateTime));

            accountStatement.Equals(accountStatementId).ShouldBe(true);
        }

        private void creating_an_account_statement()
        {
            accountStatement = accountStatementFactory.CreateAccountStatement(scrapeSessionResult);
        }

        private void an_account_statement_factory()
        {
            accountStatementFactory = new AccountStatementFactory();
        }

        private void a_scrape_session_result()
        {
            scrapeSessionResult = new ScrapeResultStub(accountId, DateTime.Now);
        }

        private void account_id()
        {
            accountId = new AccountIdStub("112345");
        }
    }
}
