namespace Aps.Domain.Scraping
{
    public struct ScrapeSessionResultCode
    {
        private enum ScrapeSessionResultCodeType
        {
            [System.ComponentModel.Description("Unknown Scraper Status")]
            Unknown,
            [StatusNotificationRule(ShouldNotifyScraper = true)]
            Pending,
            Complete,
            SiteDownForMaintenance,
            InvalidCredentials,
            Brokenscript,
        }

        private readonly ScrapeSessionResultCodeType scrapeSessionResultCode;

        public static ScrapeSessionResultCode Pending { get { return new ScrapeSessionResultCode(ScrapeSessionResultCodeType.Pending); } }
        public static ScrapeSessionResultCode SiteDownForMaintenance { get { return new ScrapeSessionResultCode(ScrapeSessionResultCodeType.SiteDownForMaintenance); } }
        public static ScrapeSessionResultCode InvalidCredentials { get { return new ScrapeSessionResultCode(ScrapeSessionResultCodeType.InvalidCredentials); } }
        public static ScrapeSessionResultCode Complete { get { return new ScrapeSessionResultCode(ScrapeSessionResultCodeType.Complete); } }
        public static ScrapeSessionResultCode BrokenScript { get { return new ScrapeSessionResultCode(ScrapeSessionResultCodeType.Brokenscript); } }

        private ScrapeSessionResultCode(ScrapeSessionResultCodeType scrapeSessionResultCode) : this()
        {
            this.scrapeSessionResultCode = scrapeSessionResultCode;
        }

        public bool ShouldNotifyScraper()
        {
            var attribute = scrapeSessionResultCode.TryGetCustomAttribute<StatusNotificationRuleAttribute>();

            if (attribute == null)
                return false;

            return attribute.ShouldNotifyScraper;
        }

        public override string ToString()
        {
            return scrapeSessionResultCode.GetDescription();
        }
    }
}