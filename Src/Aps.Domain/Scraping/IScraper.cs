using System;
using Aps.Domain.Credential;

namespace Aps.Domain.Scraping
{
    public interface IScraper
    {
        String Execute(ScraperScript scraperScript, Uri baseUri, ISecurityField securityField, IIdentificationField identificationField, IDecryptionService decrytpService);
    }
}