using System;
using Aps.Domain.Common;

namespace Aps.Domain.Company
{
    public struct AccountStatmentEntryMapping : IEquatable<AccountStatmentEntryMapping>
    {
        public AccountStatmentEntryType EntryType { get; private set; }
        public string FieldId { get; private set; }
        public bool MakeNumericValueNegative { get; private set; }

        //Adrian: I changed this to take a field ID and not a name. 
        //The reason for this is the that the same entry-type may appear twice but have different names 
        private AccountStatmentEntryMapping(AccountStatmentEntryType entryType, string fieldId, bool numericValuesAsNegative) : this()
        {
            Guard.ThatValueTypeNotDefaut(entryType, "accountStatmentEntryType");
            Guard.ThatParameterNotNullOrEmpty(fieldId, "fieldId");

            EntryType = entryType;
            FieldId = fieldId;
            MakeNumericValueNegative = numericValuesAsNegative;
        }

        public static AccountStatmentEntryMapping MapNumericValue(AccountStatmentEntryType entryType, string fieldId)
        {
            return new AccountStatmentEntryMapping(entryType, fieldId, false);
        }

        public static AccountStatmentEntryMapping MapNegativeNumericValue(AccountStatmentEntryType entryType, string fieldId)
        {
            return new AccountStatmentEntryMapping(entryType, fieldId, true);
        }

        public static AccountStatmentEntryMapping MapValue(AccountStatmentEntryType entryType, string fieldId)
        {
            return new AccountStatmentEntryMapping(entryType, fieldId, false);
        }

        public bool Equals(AccountStatmentEntryMapping other)
        {
            return EntryType.Equals(other.EntryType) && FieldId.Equals(other.FieldId);
        }
    }
}
