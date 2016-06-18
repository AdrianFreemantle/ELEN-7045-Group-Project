using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Scrap.Tests.DomainTypes;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Scrap.Tests
{
    public partial class ScrapeSessionResultCode_identity : FeatureFixture
    {
        private ScrapeSessionResultCode status1;
        private ScrapeSessionResultCode status2;
        private bool areEqual;
        
        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = status1.Equals(status2);
        }

        private void another_Scrape_Session_Result_Code(ScrapeSessionResultCode status)
        {
            status2 = status;
        }

        private void Scrape_Session_Result_Code(ScrapeSessionResultCode status)
        {
            status1 = status;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
