using System;
using Aps.Domain.Company.Tests.DomainTypes;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    [TestClass]
    [FeatureDescription(@"A base url with the same uri are equal")]
    public partial class BaseUrl_Identity
    {
        [TestMethod]
        public void a_base_url_with_the_same_uri_are_equal()
        {
            var first = new BaseUrl("http://www.validuri.com");
            var second = new BaseUrl("http://www.validuri.com");

            Runner.RunScenario(
                given => a_base_url(first),
                and => another_base_url(second),
                when => performing_an_equality_comparison(),
                then => the_two_are_equal()
                );
        }

        [TestMethod]
        public void a_base_url_with_different_uri_are_not_equal()
        {
            var first = new BaseUrl("http://www.validuri.com");
            var second = new BaseUrl("http://www.otheruri.com");

            Runner.RunScenario(
                given => a_base_url(first),
                and => another_base_url(second),
                when => performing_an_equality_comparison(),
                then => the_two_are__not_equal()
                );
        }
    }
}
