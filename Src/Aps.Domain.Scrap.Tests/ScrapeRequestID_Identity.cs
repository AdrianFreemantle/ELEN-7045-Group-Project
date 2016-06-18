using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Aps.Domain.Scrap.Tests.DomainTypes;
using Aps.Domain.Scraping;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Scrap.Tests
{
    [TestClass]
    [FeatureDescription(@"A Scrapper session ID must be uniquely identifiable")]
    public partial class ScrapeRequestID_Identity
    {
        [TestMethod]
        public void Two_ScrapSession_with_the_same_GUI_are_equal()
        {
            //Arrange

            Guid id = Guid.NewGuid();

            var SessionID1 = new ScrapeRequestId(id);
            var SessionID2 = new ScrapeRequestId(id);

            //Act and Assert

            Runner.RunScenario(
                given => a_scrapperSessionid(SessionID1),
                and => another_scrapperSessionid(SessionID2),
                when => performing_an_equality_comparision(),
                then => the_sessionID_are_equal());

        }

        [TestMethod]
        public void Two_ScrapSession_with_the_different_GUI_are_not_equal()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Guid id1 = Guid.NewGuid();

            var SessionID1 = new ScrapeRequestId(id);
            var SessionID2 = new ScrapeRequestId(id1);

            //Act and Assert

            Runner.RunScenario(
                given => a_scrapperSessionid(SessionID1),
                and => another_scrapperSessionid(SessionID2),
                when => performing_an_equality_comparision(),
                then => the_sessionID_are_not_equal());


        }
    }
}
