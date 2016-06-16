using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Scrap.Tests.DomainTypes;
using LightBDD;
using Shouldly;

namespace Aps.Domain.Scrap.Tests
{
    public partial class ScrapSessionID_Identity : FeatureFixture
    {

        private ScrapSessionID Session1;
        private ScrapSessionID Session2;
        private bool areEqual;

        private void a_scrapperSessionid(ScrapSessionID sessionId1)
        {
            Session1 = sessionId1;
        }

        private void another_scrapperSessionid(ScrapSessionID sessionId2)
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
