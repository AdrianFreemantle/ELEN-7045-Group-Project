using System;

namespace Aps.Domain.Scraping
{
    public class StatusNotificationRuleAttribute : Attribute
    {
        public bool ShouldNotifyScraper { get; set; }
    }

    public struct ScrapeSessionResultCode
    {
        private enum ScrapeSessionResultCodeType
        {
            [System.ComponentModel.Description("Unknown Scraper Status")]
            Unknown,
            [StatusNotificationRule(ShouldNotifyScraper = true)]
            pending,
            complete,
            failed,
            brokenscript,
            processed
        }

        private readonly ScrapeSessionResultCodeType scrapeSessionResultCode;

        public static ScrapeSessionResultCode Idiot { get { return new ScrapeSessionResultCode(ScrapeSessionResultCodeType.Unknown); } }
        public static ScrapeSessionResultCode Pending { get { return new ScrapeSessionResultCode(ScrapeSessionResultCodeType.pending); } }
        public static ScrapeSessionResultCode Failed { get { return new ScrapeSessionResultCode(ScrapeSessionResultCodeType.failed); } }
        public static ScrapeSessionResultCode Complete { get { return new ScrapeSessionResultCode(ScrapeSessionResultCodeType.complete); } }
        public static ScrapeSessionResultCode Processed { get { return new ScrapeSessionResultCode(ScrapeSessionResultCodeType.processed); } }
        public static ScrapeSessionResultCode BrokenScript { get { return new ScrapeSessionResultCode(ScrapeSessionResultCodeType.brokenscript); } }

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