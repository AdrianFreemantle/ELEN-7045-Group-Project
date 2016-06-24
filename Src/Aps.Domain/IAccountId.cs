using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Companies;

namespace Aps.Domain
{
    public interface IAccountId
    {
        IAccountNumber AccountNumber { get; }   
        CompanyName CompanyName { get; }   
    }
}
