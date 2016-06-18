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
    public partial class ScrapeDataAudit_Identity : FeatureFixture
    {

        private ScrapeDataAudit AuditData1;
        private ScrapeDataAudit AuditData2;
        private bool areEqual;

        private void a_ScrapeDataAudit(ScrapeDataAudit auditData1)
        {
            AuditData1 = auditData1;
        }

        private void another_ScrapeDataAudit(ScrapeDataAudit auditData2)
        {
            AuditData2 = auditData2;
        }

        private void performing_an_equality_comparision()
        {
            areEqual = AuditData1.Equals(AuditData2);
        }

        private void the_ScrapeDataAudit_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void the_ScrapeDataAudit_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
