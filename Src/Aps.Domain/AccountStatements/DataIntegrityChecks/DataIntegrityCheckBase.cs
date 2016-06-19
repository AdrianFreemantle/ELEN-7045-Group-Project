using System.Collections.Generic;
using System.Linq;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.DataIntegrityChecks
{
    public abstract class DataIntegrityCheckBase
    {
        protected Balance GetBalanceValue(ICollection<AccountStatmentEntry> statmentEntries, AccountStatmentEntryType entryType)
        {
            Guard.ThatParameterNotNullOrEmpty(statmentEntries, "statmentEntries");
            Guard.ThatValueTypeNotDefaut(entryType, "type");

            var openingBalance = statmentEntries.FirstOrDefault(e => e.EntryTypeEquals(entryType));

            // if the statment does not contain the value then just return a default as not all statments contain all fields
            if (openingBalance == null)
                return new Balance();

            Balance balance;

            if (!openingBalance.TryGetBalanceValue(out balance)) 
                throw new DataIntegrityCheckFailedException("Entry type [] does not contain a financial value");

            return balance;
        }

        public override string ToString()
        {
            return GetType().Name.SplitCamelCase();
        }
    }
}