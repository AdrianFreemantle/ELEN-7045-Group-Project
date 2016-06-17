using System;
using System.Collections.Generic;
using Aps.Domain.Common;

namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    public struct ScrapeSessionResult
    {
        public ScrapeSessionResultCode ResultCode { get; private set; }
        public IAccountId AccountId { get; private set; }
        public DateTime RunDateTime { get; private set; }
        public ICollection<ScrapeResultDataPair> TextValuePairs { get; private set; }

        public ScrapeSessionResult(ScrapeSessionResultCode resultCode, IAccountId accountId, DateTime runDateTime, ICollection<ScrapeResultDataPair> textValuePairs) :this()
        {

            Guard.ThatValueTypeNotDefaut(resultCode, "resultCode");
            Guard.ThatValueTypeNotDefaut(accountId, "accountId");
            Guard.ThatValueTypeNotDefaut(runDateTime, "runDateTime");
            Guard.ThatParameterNotNullOrEmpty(textValuePairs, "textValuePairs");

            ResultCode = resultCode;
            AccountId = accountId;
            RunDateTime = runDateTime;
            TextValuePairs = textValuePairs;
        }
    }
}