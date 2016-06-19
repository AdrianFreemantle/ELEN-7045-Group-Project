using System.Collections.Generic;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.DataIntegrityChecks
{
    public class AdditionIntegrityCheck : DataIntegrityCheckBase, IDataIntegrityCheck
    {
        public bool IsValid(ICollection<AccountStatmentEntry> statmentEntries)
        {
            Guard.ThatParameterNotNullOrEmpty(statmentEntries, "statmentEntries");

            Balance openingBalance = GetBalanceValue(statmentEntries, AccountStatmentEntryType.OpeningBalance);
            Balance paymentReceived = GetBalanceValue(statmentEntries, AccountStatmentEntryType.PaymentReceived);
            Balance newCharges = GetBalanceValue(statmentEntries, AccountStatmentEntryType.NewCharges);
            Balance discount = GetBalanceValue(statmentEntries, AccountStatmentEntryType.Discount);
            Balance deductions = GetBalanceValue(statmentEntries, AccountStatmentEntryType.Deductions);
            Balance totalDue = GetBalanceValue(statmentEntries, AccountStatmentEntryType.TotalDue);

            var calculatedTotalDue = openingBalance - paymentReceived + newCharges - discount - deductions;

            return totalDue.Equals(calculatedTotalDue);
        }
    }
}