namespace Aps.Domain.Scraping
{
    public class ScrapeRequestFactory 
    {

        public ScrapeRequest CreateScrapRequest(ScrapeRequestId scrapeRequestId, IAccountId accountId)
        {
            Guard.ThatValueTypeNotDefaut(scrapeRequestId, "scrapeRequestId");
            Guard.ThatValueTypeNotDefaut(accountId, "accountId");

            return new ScrapeRequest(scrapeRequestId, accountId);

        }
    }
}