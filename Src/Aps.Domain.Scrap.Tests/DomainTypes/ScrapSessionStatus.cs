using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    public class StatusNotificationRuleAttribute : Attribute
    {
        public bool ShouldNotifyScraper { get; set; }
    }

    public struct ScrapSessionStatus
    {
        private enum ScrapSessionStatusType
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

        private readonly ScrapSessionStatusType scrapSessionStatus;

        public static ScrapSessionStatus Idiot { get { return new ScrapSessionStatus(ScrapSessionStatusType.Unknown); } }
        public static ScrapSessionStatus Pending { get { return new ScrapSessionStatus(ScrapSessionStatusType.pending); } }
        public static ScrapSessionStatus Failed { get { return new ScrapSessionStatus(ScrapSessionStatusType.failed); } }
        public static ScrapSessionStatus Complete { get { return new ScrapSessionStatus(ScrapSessionStatusType.complete); } }
        public static ScrapSessionStatus Processed { get { return new ScrapSessionStatus(ScrapSessionStatusType.processed); } }
        public static ScrapSessionStatus BrokenScript { get { return new ScrapSessionStatus(ScrapSessionStatusType.brokenscript); } }

        private ScrapSessionStatus(ScrapSessionStatusType scrapSessionStatus)
        {
            this.scrapSessionStatus = scrapSessionStatus;
        }

        public bool ShouldNotifyScraper()
        {
            var attribute = scrapSessionStatus.TryGetCustomAttribute<StatusNotificationRuleAttribute>();

            if (attribute == null)
                return false;

            return attribute.ShouldNotifyScraper;
        }

        public override string ToString()
        {
            return scrapSessionStatus.GetDescription();
        }
    }
}