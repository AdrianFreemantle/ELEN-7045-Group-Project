using System.Collections.Generic;

namespace Aps.Domain.AccountStatements
{
    public interface IDataIntegrityCheck
    {
        bool IsValid(ICollection<StatementEntry> statementEntries);
    }
}