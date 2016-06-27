using System;
using System.Collections.Generic;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public class StatementEntry : IEquatable<StatementEntry>
    {
        private readonly StatementEntryId id;
        private readonly IAccountStatementEntryData value;
        private readonly StatementEntryType entryType;

        protected StatementEntry()
        {
        }

        internal StatementEntry(StatementEntryId id, StatementEntryType entryType, IAccountStatementEntryData value)
        {
            Guard.ThatValueTypeNotDefaut(id, "id");
            Guard.ThatValueTypeNotDefaut(entryType, "entryType");
            Guard.ThatParameterIsValueType(value, "value");

            this.id = id;
            this.value = value;
            this.entryType = entryType;
        }

        public StatementEntryDisplayValue GetDisplayValue()
        {
            return new StatementEntryDisplayValue(entryType.ToString(), value.ToString());
        }

        public string GetValue()
        {
            return value.ToString();
        }

        public bool TryGetBalanceValue(out Balance balance)
        {
            balance = new Balance();

            if (entryType.GetDataType() != StatementEntryDataType.Balance)
                return false;

            balance = (Balance)value;

            return true;
        }

        public bool Equals(StatementEntry other)
        {
            if (other == null)
                return false;

            return other.id.Equals(id);
        }

        public bool EntryTypeEquals(StatementEntryType other)
        {
            return entryType.Equals(other);
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} : {2}", id, entryType, value);
        }
    }
}