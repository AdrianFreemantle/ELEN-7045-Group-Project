using System.Collections.Generic;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;

namespace Aps.Domain.AccountStatements.AccountStatementIntegrityChecks
{
    public class AdditionIntegrityCheck : DataIntegrityCheckBase, IDataIntegrityCheck
    {
        public bool IsValid(ICollection<StatmentEntry> statmentEntries)
        {
            Guard.ThatParameterNotNullOrEmpty(statmentEntries, "statmentEntries");

            Balance openingBalance = GetBalanceValue(statmentEntries, StatmentEntryType.OpeningBalance);
            Balance paymentReceived = GetBalanceValue(statmentEntries, StatmentEntryType.PaymentReceived);
            Balance newCharges = GetBalanceValue(statmentEntries, StatmentEntryType.NewCharges);
            Balance discount = GetBalanceValue(statmentEntries, StatmentEntryType.Discount);
            Balance deductions = GetBalanceValue(statmentEntries, StatmentEntryType.Deductions);
            Balance totalDue = GetBalanceValue(statmentEntries, StatmentEntryType.TotalDue);

            var calculatedTotalDue = openingBalance - paymentReceived + newCharges - discount - deductions;

            return totalDue.Equals(calculatedTotalDue);
        }
    }
}