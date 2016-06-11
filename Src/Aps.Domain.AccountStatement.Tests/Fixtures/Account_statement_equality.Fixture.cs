using System;
using Aps.Domain.AccountStatement.Tests.DomainTypes;
using Aps.Domain.AccountStatement.Tests.Stubs;
using Aps.Domain.AccountStatements;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.AccountStatement.Tests
{
    public partial class Account_statement_equality
    {
        private CalendarMonth callCalendarMonth1;
        private CalendarMonth callCalendarMonth2;
        private AccountIdStub accountId1;
        private AccountIdStub accountId2;
        private DomainTypes.AccountStatement statement1;
        private DomainTypes.AccountStatement statement2;
        private bool result;

        private void The_two_account_statements_are_identical()
        {
            result.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            result = statement1.Equals(statement2);
        }

        private void for_account(string accountId)
        {
            accountId1 = new AccountIdStub(accountId);
            accountId2 = new AccountIdStub(accountId);

            var id1 = AccountStatementId.Create(accountId1, callCalendarMonth1);
            var id2 = AccountStatementId.Create(accountId2, callCalendarMonth2);

            statement1 = new DomainTypes.AccountStatement(id1);
            statement2 = new DomainTypes.AccountStatement(id2);
        }

        private void Two_account_statements_for_calendar_month(DateTime runTime)
        {
            callCalendarMonth1 = new CalendarMonth(runTime);
            callCalendarMonth2 = new CalendarMonth(runTime);
        }
    }
}
