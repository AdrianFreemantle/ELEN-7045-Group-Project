using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Company.Tests.DomainTypes;

namespace Aps.Domain
{
    public interface IAccountId
    {
        IAccountNumber AccountNumber { get; }   
        CompanyName CompanyName { get; }   
    }
}
