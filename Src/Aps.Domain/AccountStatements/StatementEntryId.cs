using System;

namespace Aps.Domain.AccountStatements
{
    public struct StatementEntryId
    {
        private readonly int id;

        public StatementEntryId(int id)
        {
            Guard.ThatValueTypeNotDefaut(id, "id");

            this.id = id;
        }

        public override string ToString()
        {
            return String.Format("{0:D3}", id);
        }
    }
}