using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Aps.Domain.Scrap.Tests.DomainTypes;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Scrap.Tests
{
    [TestClass]
    [FeatureDescription(@"A Scrapper should log all XML data uniquely for auditing")]
    public partial class ScrapeDataAudit_Identity
    {
        [TestMethod]
        public void Two_ScrapeDataAudit_with_the_same_Raw_XML_are_equal()
        {
            //Arrange

            var rawXML1 = new ScrapeDataAudit("Raw XML");
            var rawXML2 = new ScrapeDataAudit("Raw XML");

            //Act and Assert

            Runner.RunScenario(
                given => a_ScrapeDataAudit(rawXML1),
                and => another_ScrapeDataAudit(rawXML2),
                when => performing_an_equality_comparision(),
                then => the_ScrapeDataAudit_are_equal());

        }

        [TestMethod]
        public void Two_ScrapeDataAudit_with_the_different_Raw_XML_are_not_equal()
        {
            //Arrange

            var rawXML1 = new ScrapeDataAudit("Raw XML");
            var rawXML2 = new ScrapeDataAudit("Raw XML not the same");

            //Act and Assert

            Runner.RunScenario(
                given => a_ScrapeDataAudit(rawXML1),
                and => another_ScrapeDataAudit(rawXML2),
                when => performing_an_equality_comparision(),
                then => the_ScrapeDataAudit_are_not_equal());

        }

    }
}
