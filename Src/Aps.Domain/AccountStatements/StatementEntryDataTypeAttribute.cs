using System;

namespace Aps.Domain.AccountStatements
{
    internal class StatementEntryDataTypeAttribute : Attribute
    {
        public StatementEntryDataType Type { get; set; }
    }
}