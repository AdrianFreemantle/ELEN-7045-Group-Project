namespace Aps.Domain.Scraping
{
    public interface IScrapRequestRepository
    {
        void Save(ScrapeRequest scrapeRequest);
        ScrapeRequest fetchById(ScrapeRequestId Id);
        ScrapeRequest fetchNextPendingRequestForAccount(IAccountId accountId);
    }
}