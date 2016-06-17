using System;
using System.IO;

namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    public interface IScraperScriptParser
    {
        IScrapeSessionResult parse(String XML, IAccountId accountId);

    }
}