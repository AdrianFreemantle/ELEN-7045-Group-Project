using System;

namespace Aps.Domain.Scrap.Tests.DomainTypes
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