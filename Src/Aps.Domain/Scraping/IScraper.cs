using System;
using Aps.Domain.Companies;
using Aps.Domain.Credential;

namespace Aps.Domain.Scraping
{
    public interface IScraper
    {
        String Execute(ScraperScript scraperScript, BaseUrl baseUri, ISecurityField securityField, IIdentificationField identificationField, IDecryptionService decrytpService);
    }
}