using System;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public class AccountStatmentEntry 
    {
        private readonly int id;
        private readonly dynamic value;
        private readonly AccountStatmentEntryType entryType;

        protected AccountStatmentEntry()
        {
        }

        internal AccountStatmentEntry(int id, AccountStatmentEntryType entryType, dynamic value)
        {
            Guard.ThatValueTypeNotDefaut(id, "id");
            Guard.ThatValueTypeNotDefaut(entryType, "entryType");
            Guard.ThatValueTypeNotDefaut(value, "value");

            this.id = id;
            this.value = value;
            this.entryType = entryType;
        }

        public override string ToString()
        {
            return String.Format("{0:D3} - {1} : {2}", id, entryType, value);
        }
    }
}