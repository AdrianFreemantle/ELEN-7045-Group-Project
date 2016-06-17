using System;
using System.IO;
using Aps.Domain.Credential;

namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    public interface Scraper
    {
        String Execute(ScraperScript scraperScript, Uri baseUri, ISecurityField securityField, IIdentificationField identificationField, IDecryptionService decrytpService);
    }
}