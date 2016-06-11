using System;
using Aps.Domain.AccountStatements;

namespace Aps.Domain.AccountStatement.Tests.Tests.DomainTypes
{
    public struct AccountStatementId
    {
        private readonly CalendarMonth calendarMonth;
        private readonly IAccountId accountId;

        private AccountStatementId(IAccountId accountId, CalendarMonth calendarMonth)
        {
            this.accountId = accountId;
            this.calendarMonth = calendarMonth;
        }

        public static AccountStatementId Create<TAccountId>(TAccountId accountId, CalendarMonth calendarMonth) where TAccountId : struct, IAccountId
        {
            Guard.ThatParameterNotDefaut(accountId, "accountId");
            Guard.ThatParameterNotDefaut(calendarMonth, "calendarMonth");

            return new AccountStatementId(accountId, calendarMonth);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", accountId, calendarMonth);
        }
    }
}