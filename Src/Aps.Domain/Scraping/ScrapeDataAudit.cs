using System;

namespace Aps.Domain.Scraping
{
    public struct ScrapeDataAudit
    {
        private readonly String rawXML;

        public ScrapeDataAudit(string rawXml)
        {
            Guard.ThatParameterNotNullOrEmpty(rawXml, "rawXml");
            rawXML = rawXml;
        }
    }
}