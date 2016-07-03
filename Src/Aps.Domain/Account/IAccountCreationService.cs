using Aps.Domain.Companies;
using Aps.Domain.Credential;

namespace Aps.Domain.Account
{
    interface IAccountCreationService
    {
        void CreateAccount(CompanyName companyname, AccountNumber accountNumber);
    }
}
