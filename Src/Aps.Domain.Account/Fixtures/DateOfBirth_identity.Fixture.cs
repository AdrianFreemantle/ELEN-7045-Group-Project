using Aps.Domain.Common;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Account.Tests
{
    public partial class DateOfBirth_identity : FeatureFixture
    {
        private DateOfBirth date1;
        private DateOfBirth date2;
        private bool areEqual;


        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = date1.Equals(date2);
        }

        private void another_dateofBirth(DateOfBirth date)
        {
            date2 = date;
        }

        private void dateofBirth(DateOfBirth date)
        {
            date1 = date;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
