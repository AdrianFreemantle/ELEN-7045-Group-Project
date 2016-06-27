using System.Collections.Generic;
using System.Linq;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;

namespace Aps.Domain.AccountStatements.AccountStatementIntegrityChecks
{
    public abstract class DataIntegrityCheckBase
    {
        protected Balance GetBalanceValue(ICollection<StatementEntry> statementEntries, StatementEntryType entryType)
        {
            Guard.ThatParameterNotNullOrEmpty(statementEntries, "statementEntries");
            Guard.ThatValueTypeNotDefaut(entryType, "type");

            var openingBalance = statementEntries.FirstOrDefault(e => e.EntryTypeEquals(entryType));

            // if the statement does not contain the value then just return a default as not all statements contain all fields
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