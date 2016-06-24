using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    [TestClass]
    [FeatureDescription(@"A base url must be made up of a valid Uri")]
    public partial class BaseUrl_create
    {
        [TestMethod]
        public void given_a_valid_uri_when_creating_a_base_url_then_the_base_url_is_valid()
        {
            Runner.RunScenario(
                given => a_uri_string("http://www.validuri.com"),
                when => creating_a_base_url(),
                then => the_base_url_is_valid()
                );
        }

        [TestMethod]
        public void given_a_invalid_uri_when_creating_a_base_url_then_the_base_url_is_invalid()
        {
            Runner.RunScenario(
                given => a_uri_string(string.Empty),
                when => creating_a_base_url(),
                then => the_base_url_is_invalid()
                );
        }

        [TestMethod]
        public void given_a_null_uri_when_creating_a_base_url_then_the_base_url_is_invalid()
        {
            Runner.RunScenario(
                given => a_uri_string(null),
                when => creating_a_base_url(),
                then => the_base_url_is_invalid()
                );
        }
    }
}
