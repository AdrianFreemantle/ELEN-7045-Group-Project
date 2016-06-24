using System;

namespace Aps.Domain.AccountStatements.StatementEntryDataTypes
{
    public struct TextValue : IAccountStatementEntryData
    {
        private readonly string value;

        public TextValue(string value)
        {
            Guard.ThatParameterNotNullOrEmpty(value, "value");
            this.value = value.Trim();
        }

        public override string ToString()
        {
            return value;
        }

        public string ToString(string format, IFormatProvider formatProvider) //formatting that could be applied include: uppercase, capitalisation etc
        {
            return value;
        }
    }
}