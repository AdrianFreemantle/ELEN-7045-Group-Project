namespace Aps.Domain.Companies
{
    public interface ICompanyRepository
    {
        Company FetchByName(ICompanyName companyName);
    }
}