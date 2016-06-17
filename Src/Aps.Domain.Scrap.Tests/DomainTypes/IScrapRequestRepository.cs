namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    public interface IScrapRequestRepository
    {
        void Save(ScrapeRequest scrapeRequest);
        ScrapeRequest fetchById(ScrapeRequestId Id);
        ScrapeRequest fetchNextPendingRequestForAccount(IAccountId accountId);
    }
}