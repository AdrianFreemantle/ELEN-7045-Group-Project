using System;
using System.IO.Pipes;
using Aps.Domain.AccountStatement.Tests.Tests.DomainTypes;
using Aps.Domain.AccountStatement.Tests.Tests.Stubs;
using Aps.Domain.AccountStatements;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Aps.Domain.AccountStatement.Tests.Tests
{
    [TestClass]
    [FeatureDescription(@"An account factory creates a valid instance of an account")]
    public partial class Account_statement_factory : FeatureFixture
    {
        private IScrapeSessionResult scrapeSessionResult;
        private AccountStatementFactory accountStatementFactory;
        private AccountStatement accountStatement;
        private AccountStatementId accountStatementId;


        [TestMethod]
        public void Scrape()
        {
            Runner.RunScenario(
                given => a_scrape_session_result_for_account(new AccountIdStub("12345")),
                and => an_account_statement_factory(),
                when => an_account_statement_is_created(),
                then => an_account_statement_is_returned());
        }

        private void an_account_statement_factory()
        {
            accountStatementFactory = new AccountStatementFactory();
        }

        private void a_scrape_session_result_for_account(AccountIdStub accountId)
        {
            scrapeSessionResult = new ScrapeResultStub(accountId, DateTime.Now);
            var callCalendarMonth = new CalendarMonth(scrapeSessionResult.RunDateTime);

            accountStatementId = AccountStatementId.Create(accountId, callCalendarMonth);
        }

        private void an_account_statement_is_returned()
        {
            accountStatement.Equals(accountStatementId).ShouldBe(true); 
        }

        private void an_account_statement_is_created()
        {
            accountStatement = accountStatementFactory.CreateAccountStatement(scrapeSessionResult);
        }
    }

    public class AccountStatement : IEquatable<AccountStatementId>, IEquatable<AccountStatement>
    {
        private readonly AccountStatementId id;

        public AccountStatement(AccountStatementId id)
        {
            this.id = id;
        }

        public bool Equals(AccountStatementId other)
        {
            return id.Equals(other);
        }

        public bool Equals(AccountStatement other)
        {
            if (other == null)
                return false;

            return Equals(other.id);
        }
    }

    public class AccountStatementFactory
    {
        public AccountStatement CreateAccountStatement(IScrapeSessionResult scrapeSessionResult)
        {
            throw new NotImplementedException();
        }
    }
}