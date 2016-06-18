using System;

namespace Aps.Domain.Scraping
{
    public interface IScraperScriptParser
    {
        ScrapeSessionResult parse(String XML, IAccountId accountId);
    }
}