using System;
using System.Collections.Generic;
using Aps.Domain.Common;

namespace Aps.Domain
{
    public interface IScrapeSessionResult
    {
        IScrapeSessionResultCode ResultCode { get; }
        IAccountId AccountId { get; }
        DateTime RunDateTime { get; }
        Uri BaseUri { get; }
        ICollection<ScrapeResultDataPair> TextValuePairs { get; }
    }
}