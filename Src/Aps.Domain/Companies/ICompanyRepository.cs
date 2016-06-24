namespace Aps.Domain.Companies
{
    public interface ICompanyRepository
    {
        Company FetchByName(CompanyName companyName);
    }
}