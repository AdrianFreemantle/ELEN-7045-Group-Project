using Aps.Domain.AccountStatements;

namespace Aps.Domain.Company
{
    public interface IDataIntegrityCheckOverride
    {
        bool Override(IDataIntegrityCheck check);
    }
}