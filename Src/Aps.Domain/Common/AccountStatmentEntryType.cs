using System;
using System.ComponentModel;

namespace Aps.Domain.Common
{
    public struct AccountStatmentEntryType
    {
        private readonly AccountStatementEntryEnum entryType;

        private enum AccountStatementEntryEnum
        {
            Unknown,

            [StatementEntryDataType(Type = DataType.Text)]
            AccountNumber,

            [StatementEntryDataType(Type = DataType.Text)]
            AccountHolderName,

            [StatementEntryDataType(Type = DataType.Date)]
            StatementDate,

            [StatementEntryDataType(Type = DataType.Text)]
            StatementNumber,

            [StatementEntryDataType(Type = DataType.Month)]
            StatementMonth,

            [StatementEntryDataType(Type = DataType.Balance)]
            TotalDue,

            [StatementEntryDataType(Type = DataType.Date)]
            DueDate,

            [StatementEntryDataType(Type = DataType.Balance)]
            OpeningBalance,

            [StatementEntryDataType(Type = DataType.Balance)]
            ClosingBalance,

            [StatementEntryDataType(Type = DataType.Balance)]
            PaymentReceived,

            [StatementEntryDataType(Type = DataType.Balance)]
            NewCharges,

            [StatementEntryDataType(Type = DataType.Balance)]
            Deductions,

            [StatementEntryDataType(Type = DataType.Balance)]
            Discount,

            [Description("VAT Amount")]
            [StatementEntryDataType(Type = DataType.Balance)]
            VatAmount
        }

        public static AccountStatmentEntryType AccountNumber
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.AccountNumber); }
        }

        public static AccountStatmentEntryType AccountHolderName
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.AccountHolderName); }
        }

        public static AccountStatmentEntryType StatementDate
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.StatementDate); }
        }

        public static AccountStatmentEntryType StatementNumber
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.StatementNumber); }
        }

        public static AccountStatmentEntryType StatementMonth
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.StatementMonth); }
        }

        public static AccountStatmentEntryType TotalDue
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.TotalDue); }
        }

        public static AccountStatmentEntryType DueDate
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.DueDate); }
        }

        public static AccountStatmentEntryType ClosingBalance
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.ClosingBalance); }
        }

        public static AccountStatmentEntryType PaymentReceived
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.PaymentReceived); }
        }

        public static AccountStatmentEntryType NewCharges
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.NewCharges); }
        }

        public static AccountStatmentEntryType Deductions
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.Deductions); }
        }

        public static AccountStatmentEntryType OpeningBalance
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.OpeningBalance); }
        }

        public static AccountStatmentEntryType Discount
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.Discount); }
        }

        public static AccountStatmentEntryType VatAmount
        {
            get { return new AccountStatmentEntryType(AccountStatementEntryEnum.VatAmount); }
        }

        private AccountStatmentEntryType(AccountStatementEntryEnum entryType)
        {
            this.entryType = entryType;
        }

        internal DataType GetDataType()
        {
            var attribute = entryType.TryGetCustomAttribute<StatementEntryDataTypeAttribute>();

            if (attribute == null)
                throw new InvalidOperationException("Unable to retrieve StatementEntryDataTypeAttribute");

            return attribute.Type;
        }

        public override string ToString()
        {
            return entryType.ToString();
        }
    }
}
