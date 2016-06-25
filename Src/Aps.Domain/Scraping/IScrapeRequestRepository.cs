namespace Aps.Domain.Scraping
{
    public interface IScrapeRequestRepository
    {
        void Save(ScrapeRequest scrapeRequest);
        ScrapeRequest fetchById(ScrapeRequestId Id);
        ScrapeRequest fetchNextPendingRequestForAccount(IAccountId accountId);
    }
}