using Aps.Domain.Scraping;

namespace Aps.Domain.AccountStatements
{
    public interface IAccountStatmentCreationService
    {
        void CreateAccountStatementFromScrapeResult(ScrapeSessionResult scrapeSessionResult);
    }
}