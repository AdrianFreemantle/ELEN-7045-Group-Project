using Aps.Domain.Common;
using Aps.Domain.Credential;
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
            IDecryptionService service = new Encryption();
            areEqual = date1.GetDateTime(service).Equals(date2.GetDateTime(service));
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
