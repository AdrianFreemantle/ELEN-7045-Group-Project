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
            Guard.ThatValueTypeNotDefaut(value, "value");

            this.id = id;
            this.value = value;
            this.entryType = entryType;
        }

        public AccountStatementEntryDisplayValue GetDisplayValue()
        {
            return new AccountStatementEntryDisplayValue(entryType.ToString(), value.ToString());
        }

        public bool Equals(AccountStatmentEntry other)
        {
            if (other == null)
                return false;

            return other.id.Equals(id);
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} : {2}", id, entryType, value);
        }
    }

    public struct AccountStatementEntryDisplayValue
    {
        private readonly string description;
        private readonly string value;

        public string Description { get { return description; }}
        public string Value { get { return value; } }

        internal AccountStatementEntryDisplayValue(string description, string value)
        {
            Guard.ThatParameterNotNullOrEmpty(description, "description");
            Guard.ThatParameterNotNullOrEmpty(value, "value");

            this.description = description;
            this.value = value;
        }
    }
}