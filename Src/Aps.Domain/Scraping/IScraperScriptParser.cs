using System;
using Aps.Domain.Account;

namespace Aps.Domain.Scraping
{
    public interface IScraperScriptParser
    {
        ScrapeSessionResult parse(String XML, AccountId accountId);
    }
}