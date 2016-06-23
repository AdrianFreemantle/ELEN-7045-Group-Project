using System;
using Aps.Domain.Company.Tests.DomainTypes;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    public partial class BaseUrl_create : FeatureFixture
    {
        private string _stringUrl;
        private Uri _uri;
        private BaseUrl _baseUrl;
        private Exception _error;

        private void a_uri_string(string url)
        {
            _stringUrl = url;
        }

        private void creating_a_base_url()
        {
            try
            {
                _baseUrl = new BaseUrl(_stringUrl);
            }
            catch (Exception exception)
            {
                _error = exception;
            }
        }

        private void the_base_url_is_valid()
        {
            Assert.IsNull(_error);
        }

        private void the_base_url_is_invalid()
        {
            Assert.IsNotNull(_error);
        }
    }
}
