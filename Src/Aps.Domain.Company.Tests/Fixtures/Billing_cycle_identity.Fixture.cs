using Aps.Domain.Companies;
using LightBDD;
using Shouldly;

namespace Aps.Domain.Company.Tests
{
    public partial class Billing_cycle_identity : FeatureFixture
    {
        private BillingCycle _billingCycle1;
        private BillingCycle _billingCycle2;
        private bool _areEqual;

        private void a_billing_cycle(BillingCycle first)
        {
            _billingCycle1 = first;
        }

        private void another_billing_cycle(BillingCycle second)
        {
            _billingCycle2 = second;
        }

        private void performing_an_equality_comparison()
        {
            _areEqual = _billingCycle1.Equals(_billingCycle2);
        }

        private void then_the_two_are_equal()
        {
            _areEqual.ShouldBe(true);
        }

        private void then_the_two_are_not_equal()
        {
            _areEqual.ShouldBe(false);
        }
    }
}
