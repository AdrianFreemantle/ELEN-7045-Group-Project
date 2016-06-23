using System;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public struct BaseUrl
    {
        private readonly Uri _baseUri;

        public BaseUrl(string baseUrl)
        {
            _baseUri = new Uri(baseUrl);
        }

        public override string ToString()
        {
            return _baseUri.AbsoluteUri;
        }
    }
}
