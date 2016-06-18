using System;

namespace Aps.Domain.Scraping
{
    public interface IScraperScriptParser
    {
        IScrapeSessionResult parse(String XML, IAccountId accountId);

    }
}