using System;

namespace Aps.Domain.Common
{
    internal class StatementEntryDataTypeAttribute : Attribute
    {
        public DataType Type { get; set; }
    }
}