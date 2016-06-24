using System;

namespace Aps.Domain.AccountStatements
{
    public struct StatmentEntryId
    {
        private readonly int id;

        public StatmentEntryId(int id)
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