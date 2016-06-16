using System;
using System.Collections.Generic;
using System.Linq;
using Aps.Domain.AccountStatements.Tests.DomainTypes;
using Aps.Domain.AccountStatements.Tests.Stubs;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Aps.Domain.AccountStatements.Tests
{
    [TestClass]
    [ScenarioCategory("Account Statements")]
    [FeatureDescription(@"As a customer I want to view previous account statements for an account so that I can track my payment history or dispute discrepancies")]
    public partial class Previous_account_statements
    {
        [TestMethod]
        public void Account_statement_repository_cant_fetch_all_prior_statments_for_an_account()
        {
            AccountStatmentRepositoryStub repository = new AccountStatmentRepositoryStub();
            AccountIdStub accountId = new AccountIdStub("12345");
            CalendarMonth month = new CalendarMonth(DateTime.Now);
            AccountStatementId accountStatementId = AccountStatementId.Create(accountId, month);
            AccountStatement statement = new AccountStatement(accountStatementId);
            repository.Save(statement);

            ICollection<AccountStatement> result = repository.FetchAllForAccount(new AccountIdStub("12345"));
            result.Any().ShouldBe(true);
        }
    }

    
}