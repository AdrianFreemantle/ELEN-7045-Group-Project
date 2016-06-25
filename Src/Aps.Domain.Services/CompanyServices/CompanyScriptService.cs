using Aps.Domain.Companies;

namespace Aps.Domain.Services.CompanyServices
{
    public class CompanyScriptService : ICompanyScriptService
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyScriptService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public void SetScriptAsBroken(CompanyName companyName)
        {
            Company company = companyRepository.FetchByName(companyName);
            company.SetScriptAsBroken();
        }
    }
}