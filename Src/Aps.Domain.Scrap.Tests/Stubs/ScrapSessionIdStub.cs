namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    public struct ScrapSessionIdStub : IScrapeSessionId
    {
        private readonly string scrapSessionId;

        public ScrapSessionIdStub(string scrapSessionId)
        {
            this.scrapSessionId = scrapSessionId;
        }

        public override string ToString()
        {
            return scrapSessionId;
        }
    }
}