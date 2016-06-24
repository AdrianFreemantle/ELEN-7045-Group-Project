using System;
using Aps.Domain.AccountStatements;
using Aps.Domain.Common;

namespace Aps.Domain.Company
{
    public struct AccountStatmentEntryMapping : IEquatable<AccountStatmentEntryMapping>
    {
        public StatmentEntryType EntryType { get; private set; }
        public string FieldId { get; private set; }
        public bool MakeNumericValueNegative { get; private set; }

        //Adrian: I changed this to take a field ID and not a name. 
        //The reason for this is the that the same entry-type may appear twice but have different names 
        private AccountStatmentEntryMapping(StatmentEntryType entryType, string fieldId, bool numericValuesAsNegative) : this()
        {
            Guard.ThatValueTypeNotDefaut(entryType, "accountStatmentEntryType");
            Guard.ThatParameterNotNullOrEmpty(fieldId, "fieldId");

            EntryType = entryType;
            FieldId = fieldId;
            MakeNumericValueNegative = numericValuesAsNegative;
        }

        public static AccountStatmentEntryMapping MapNumericValue(StatmentEntryType entryType, string fieldId)
        {
            return new AccountStatmentEntryMapping(entryType, fieldId, false);
        }

        public static AccountStatmentEntryMapping MapNegativeNumericValue(StatmentEntryType entryType, string fieldId)
        {
            return new AccountStatmentEntryMapping(entryType, fieldId, true);
        }

        public static AccountStatmentEntryMapping MapValue(StatmentEntryType entryType, string fieldId)
        {
            return new AccountStatmentEntryMapping(entryType, fieldId, false);
        }

        public bool Equals(AccountStatmentEntryMapping other)
        {
            return EntryType.Equals(other.EntryType) && FieldId.Equals(other.FieldId);
        }
    }
}
