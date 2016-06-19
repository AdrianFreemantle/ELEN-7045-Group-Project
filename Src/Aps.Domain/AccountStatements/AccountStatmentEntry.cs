using System;
using System.Collections.Generic;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public class AccountStatmentEntry : IEquatable<AccountStatmentEntry>
    {
        private readonly AccountStatmentEntryId id;
        private readonly dynamic value;
        private readonly AccountStatmentEntryType entryType;

        protected AccountStatmentEntry()
        {
        }

        internal AccountStatmentEntry(AccountStatmentEntryId id, AccountStatmentEntryType entryType, IFormattable value)
        {
            Guard.ThatValueTypeNotDefaut(id, "id");
            Guard.ThatValueTypeNotDefaut(entryType, "entryType");
            Guard.ThatParameterIsValueType(value, "value");

            this.id = id;
            this.value = value;
            this.entryType = entryType;
        }

        public AccountStatementEntryDisplayValue GetDisplayValue()
        {
            return new AccountStatementEntryDisplayValue(entryType.ToString(), value.ToString());
        }

        public string GetValue()
        {
            return value.ToString();
        }

        public bool TryGetBalanceValue(out Balance balance)
        {
            balance = new Balance();

            if (entryType.GetDataType() != DataType.Balance)
                return false;

            balance = (Balance)value;

            return true;
        }

        public bool Equals(AccountStatmentEntry other)
        {
            if (other == null)
                return false;

            return other.id.Equals(id);
        }

        public bool EntryTypeEquals(AccountStatmentEntryType other)
        {
            return entryType.Equals(other);
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} : {2}", id, entryType, value);
        }
    }
}