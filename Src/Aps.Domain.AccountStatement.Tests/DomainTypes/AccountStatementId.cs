using System;

namespace Aps.Domain.AccountStatements.Tests.DomainTypes
{
    public struct AccountStatementId
    {
        private readonly CalendarMonth calendarMonth;
        private readonly IAccountId accountId;

        internal CalendarMonth Month
        {
            get { return calendarMonth; }
        }

        internal IAccountId AccountId
        {
            get { return accountId; }
        }

        private AccountStatementId(IAccountId accountId, CalendarMonth calendarMonth)
        {
            this.accountId = accountId;
            this.calendarMonth = calendarMonth;
        }

        public static AccountStatementId Create(IAccountId accountId, DateTime runTime)
        {
            Guard.ThatValueTypeNotDefaut(accountId, "accountId");
            Guard.ThatValueTypeNotDefaut(runTime, "runTime");

            return new AccountStatementId(accountId, new CalendarMonth(runTime));
        }

        public static AccountStatementId Create(IAccountId accountId, CalendarMonth calendarMonth) 
        {
            Guard.ThatValueTypeNotDefaut(accountId, "accountId");
            Guard.ThatValueTypeNotDefaut(calendarMonth, "calendarMonth");

            return new AccountStatementId(accountId, calendarMonth);
        }

        public override string ToString()
        {
            return String.Format("{0}-{1}", accountId, calendarMonth);
        }
    }
}