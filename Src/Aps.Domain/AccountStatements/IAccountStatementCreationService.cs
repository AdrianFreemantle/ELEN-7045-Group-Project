using Aps.Domain.Scraping;

namespace Aps.Domain.AccountStatements
{
    public interface IAccountStatementCreationService
    {
        void CreateAccountStatementFromScrapeResult(ScrapeSessionResult scrapeSessionResult);
    }
}