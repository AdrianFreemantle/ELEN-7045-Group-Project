using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Scrap.Tests.DomainTypes;
using Aps.Domain.Scraping;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Scrap.Tests
{
    public partial class ScrapeRequestID_Identity : FeatureFixture
    {

        private ScrapeRequestId Session1;
        private ScrapeRequestId Session2;
        private bool areEqual;

        private void a_scrapperSessionid(ScrapeRequestId sessionId1)
        {
            Session1 = sessionId1;
        }

        private void another_scrapperSessionid(ScrapeRequestId sessionId2)
        {
            Session2 = sessionId2;
        }

        private void performing_an_equality_comparision()
        {
            areEqual = Session1.Equals(Session2);
        }

        private void the_sessionID_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void the_sessionID_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
