using System;
using System.Collections.Generic;
using Aps.Domain.Common;

namespace Aps.Domain
{
  public interface IScrapeSessionResult
    {
        IAccountId AccountId { get; }
        DateTime RunDateTime { get; }
        Uri BaseUri { get; }
        ICollection<ScrapeResultDataPair> TextValuePairs { get; }
    }
}