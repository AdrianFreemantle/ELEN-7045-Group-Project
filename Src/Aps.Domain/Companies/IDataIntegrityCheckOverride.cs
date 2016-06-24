using Aps.Domain.AccountStatements;

namespace Aps.Domain.Companies
{
    public interface IDataIntegrityCheckOverride
    {
        bool Override(IDataIntegrityCheck check);
    }
}