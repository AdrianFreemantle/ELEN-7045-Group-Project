using System;
using Aps.Domain.AccountStatements;

namespace Aps.Domain.Companies
{
    public struct AccountStatementEntryMapping : IEquatable<AccountStatementEntryMapping>
    {
        public StatementEntryType EntryType { get; private set; }
        public string FieldId { get; private set; }
        public bool MakeNumericValueNegative { get; private set; }

        //Adrian: I changed this to take a field ID and not a name. 
        //The reason for this is the that the same entry-type may appear twice but have different names 
        private AccountStatementEntryMapping(StatementEntryType entryType, string fieldId, bool numericValuesAsNegative) : this()
        {
            Guard.ThatValueTypeNotDefaut(entryType, "accountStatementEntryType");
            Guard.ThatParameterNotNullOrEmpty(fieldId, "fieldId");

            EntryType = entryType;
            FieldId = fieldId;
            MakeNumericValueNegative = numericValuesAsNegative;
        }

        public static AccountStatementEntryMapping MapNumericValue(StatementEntryType entryType, string fieldId)
        {
            return new AccountStatementEntryMapping(entryType, fieldId, false);
        }

        public static AccountStatementEntryMapping MapNegativeNumericValue(StatementEntryType entryType, string fieldId)
        {
            return new AccountStatementEntryMapping(entryType, fieldId, true);
        }

        public static AccountStatementEntryMapping MapValue(StatementEntryType entryType, string fieldId)
        {
            return new AccountStatementEntryMapping(entryType, fieldId, false);
        }

        public bool Equals(AccountStatementEntryMapping other)
        {
            return EntryType.Equals(other.EntryType) && FieldId.Equals(other.FieldId);
        }
    }
}
