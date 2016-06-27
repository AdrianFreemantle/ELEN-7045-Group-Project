using System.Collections.Generic;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;

namespace Aps.Domain.AccountStatements.AccountStatementIntegrityChecks
{
    public class AdditionIntegrityCheck : DataIntegrityCheckBase, IDataIntegrityCheck
    {
        public bool IsValid(ICollection<StatementEntry> statementEntries)
        {
            Guard.ThatParameterNotNullOrEmpty(statementEntries, "statementEntries");

            Balance openingBalance = GetBalanceValue(statementEntries, StatementEntryType.OpeningBalance);
            Balance paymentReceived = GetBalanceValue(statementEntries, StatementEntryType.PaymentReceived);
            Balance newCharges = GetBalanceValue(statementEntries, StatementEntryType.NewCharges);
            Balance discount = GetBalanceValue(statementEntries, StatementEntryType.Discount);
            Balance deductions = GetBalanceValue(statementEntries, StatementEntryType.Deductions);
            Balance totalDue = GetBalanceValue(statementEntries, StatementEntryType.TotalDue);

            var calculatedTotalDue = openingBalance - paymentReceived + newCharges - discount - deductions;

            return totalDue.Equals(calculatedTotalDue);
        }
    }
}