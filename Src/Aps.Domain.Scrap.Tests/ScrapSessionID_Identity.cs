using System;
using Aps.Domain.Scrap.Tests.DomainTypes;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Scrap.Tests
{
    [TestClass]
    [FeatureDescription(@"A Scrapper session ID must be uniquely identifiable")]
    public partial class ScrapSessionID_Identity
    {
        [TestMethod]
        public void Two_ScrapSession_with_the_same_GUI_are_equal()
        {
            //Arrange
            
            var SessionID1 = new ScrapSessionID("A12345");
            var SessionID2 = new ScrapSessionID("A12345");

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

            var SessionID1 = new ScrapSessionID("A12345");
            var SessionID2 = new ScrapSessionID("B12345");

            //Act and Assert

            Runner.RunScenario(
                given => a_scrapperSessionid(SessionID1),
                and => another_scrapperSessionid(SessionID2),
                when => performing_an_equality_comparision(),
                then => the_sessionID_are_not_equal());

           
        }
    }
}
