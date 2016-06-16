namespace Aps.Domain.AccountStatements.Tests
{
    public class AccountStatmentEntry
    {
        private readonly int id;
        private readonly dynamic value;

        protected AccountStatmentEntry()
        {
        }

        internal AccountStatmentEntry(int id, dynamic value)
        {
            Guard.ThatValueTypeNotDefaut(id, "id");
            Guard.ThatValueTypeNotDefaut(value, "value");

            this.id = id;
            this.value = value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}