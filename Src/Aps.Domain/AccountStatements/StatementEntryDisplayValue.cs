namespace Aps.Domain.AccountStatements
{
    public struct StatementEntryDisplayValue
    {
        private readonly string description;
        private readonly string value;

        public string Description { get { return description; }}
        public string Value { get { return value; } }

        internal StatementEntryDisplayValue(string description, string value)
        {
            Guard.ThatParameterNotNullOrEmpty(description, "description");
            Guard.ThatParameterNotNullOrEmpty(value, "value");

            this.description = description;
            this.value = value;
        }
    }
}