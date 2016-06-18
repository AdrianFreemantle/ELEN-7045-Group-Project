using System;
using System.Collections.Generic;
using System.Linq;
using Aps.Domain.AccountStatements.Tests.Stubs;
using Aps.Domain.Common;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.AccountStatements.Tests
{
    public partial class Previous_account_statements : FeatureFixture
    {
        private AccountStatmentRepositoryStub repository;
        private AccountIdStub accountId;
        private CalendarMonth month;
        private AccountStatementId accountStatementId;
        private AccountStatement statement;
        private ICollection<AccountStatement> result;

        private void account_statements_are_returned()
        {
            result.Any().ShouldBe(true);
        }

        private void fetching_all_account_statements_for_account_number(string accountNumber)
        {
            result = repository.FetchAllForAccount(new AccountIdStub(accountNumber));
        }

        private void it_contains_account_statements_for_account(string accountNumber)
        {
            month = new CalendarMonth(DateTime.Now);
            accountId = new AccountIdStub(accountNumber);
            accountStatementId = AccountStatementId.Create(accountId, month);
            statement = new AccountStatement(accountStatementId, new List<AccountStatmentEntry>());
            repository.Save(statement);
        }

        private AccountStatmentRepositoryStub an_account_statement_repository()
        {
            return repository = new AccountStatmentRepositoryStub();
        }
    }
}