using System;
using System.ComponentModel;

namespace Aps.Domain.AccountStatements
{
    public struct StatementEntryType
    {
        private readonly AccountStatementEntryEnum entryType;

        private enum AccountStatementEntryEnum
        {
            Unknown,

            [StatementEntryDataType(Type = StatementEntryDataType.Text)]
            AccountNumber,

            [StatementEntryDataType(Type = StatementEntryDataType.Text)]
            AccountHolderName,

            [StatementEntryDataType(Type = StatementEntryDataType.Date)]
            StatementDate,

            [StatementEntryDataType(Type = StatementEntryDataType.Text)]
            StatementNumber,

            [StatementEntryDataType(Type = StatementEntryDataType.Month)]
            StatementMonth,

            [StatementEntryDataType(Type = StatementEntryDataType.Balance)]
            TotalDue,

            [StatementEntryDataType(Type = StatementEntryDataType.Date)]
            DueDate,

            [StatementEntryDataType(Type = StatementEntryDataType.Balance)]
            OpeningBalance,

            [StatementEntryDataType(Type = StatementEntryDataType.Balance)]
            ClosingBalance,

            [StatementEntryDataType(Type = StatementEntryDataType.Balance)]
            PaymentReceived,

            [StatementEntryDataType(Type = StatementEntryDataType.Balance)]
            NewCharges,

            [StatementEntryDataType(Type = StatementEntryDataType.Balance)]
            Deductions,

            [StatementEntryDataType(Type = StatementEntryDataType.Balance)]
            Discount,

            [Description("VAT Amount")]
            [StatementEntryDataType(Type = StatementEntryDataType.Balance)]
            VatAmount,

            [StatementEntryDataType(Type = StatementEntryDataType.KilowattHour)]
            ElectricityUsed,
                
            [StatementEntryDataType(Type = StatementEntryDataType.Percentage)]
            InterestRate,

            [StatementEntryDataType(Type = StatementEntryDataType.Duration)]
            TotalCallDuration
        }

        public static StatementEntryType AccountNumber
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.AccountNumber); }
        }

        public static StatementEntryType AccountHolderName
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.AccountHolderName); }
        }

        public static StatementEntryType StatementDate
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.StatementDate); }
        }

        public static StatementEntryType StatementNumber
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.StatementNumber); }
        }

        public static StatementEntryType StatementMonth
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.StatementMonth); }
        }

        public static StatementEntryType TotalDue
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.TotalDue); }
        }

        public static StatementEntryType DueDate
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.DueDate); }
        }

        public static StatementEntryType ClosingBalance
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.ClosingBalance); }
        }

        public static StatementEntryType PaymentReceived
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.PaymentReceived); }
        }

        public static StatementEntryType NewCharges
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.NewCharges); }
        }

        public static StatementEntryType Deductions
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.Deductions); }
        }

        public static StatementEntryType OpeningBalance
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.OpeningBalance); }
        }

        public static StatementEntryType Discount
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.Discount); }
        }

        public static StatementEntryType VatAmount
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.VatAmount); }
        }

        public static StatementEntryType ElectricityUsed
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.ElectricityUsed); }
        }

        public static StatementEntryType InterestRate
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.InterestRate); }
        }

        public static StatementEntryType TotalCallDuration
        {
            get { return new StatementEntryType(AccountStatementEntryEnum.TotalCallDuration); }
        }

        private StatementEntryType(AccountStatementEntryEnum entryType)
        {
            this.entryType = entryType;
        }

        internal StatementEntryDataType GetDataType()
        {
            var attribute = entryType.TryGetCustomAttribute<StatementEntryDataTypeAttribute>();

            if (attribute == null)
                throw new InvalidOperationException("Unable to retrieve StatementEntryDataTypeAttribute");

            return attribute.Type;
        }

        public override string ToString()
        {
            return entryType.GetDescription();
        }
    }
}
