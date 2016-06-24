using System;
using System.ComponentModel;

namespace Aps.Domain.AccountStatements
{
    public struct StatmentEntryType
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

        public static StatmentEntryType AccountNumber
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.AccountNumber); }
        }

        public static StatmentEntryType AccountHolderName
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.AccountHolderName); }
        }

        public static StatmentEntryType StatementDate
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.StatementDate); }
        }

        public static StatmentEntryType StatementNumber
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.StatementNumber); }
        }

        public static StatmentEntryType StatementMonth
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.StatementMonth); }
        }

        public static StatmentEntryType TotalDue
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.TotalDue); }
        }

        public static StatmentEntryType DueDate
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.DueDate); }
        }

        public static StatmentEntryType ClosingBalance
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.ClosingBalance); }
        }

        public static StatmentEntryType PaymentReceived
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.PaymentReceived); }
        }

        public static StatmentEntryType NewCharges
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.NewCharges); }
        }

        public static StatmentEntryType Deductions
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.Deductions); }
        }

        public static StatmentEntryType OpeningBalance
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.OpeningBalance); }
        }

        public static StatmentEntryType Discount
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.Discount); }
        }

        public static StatmentEntryType VatAmount
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.VatAmount); }
        }

        public static StatmentEntryType ElectricityUsed
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.ElectricityUsed); }
        }

        public static StatmentEntryType InterestRate
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.InterestRate); }
        }

        public static StatmentEntryType TotalCallDuration
        {
            get { return new StatmentEntryType(AccountStatementEntryEnum.TotalCallDuration); }
        }

        private StatmentEntryType(AccountStatementEntryEnum entryType)
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
