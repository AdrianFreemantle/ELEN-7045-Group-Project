using System;

namespace Aps.Domain.Scraping
{
    public class StatusNotificationRuleAttribute : Attribute
    {
        public bool ShouldNotifyScraper { get; set; }
    }
}