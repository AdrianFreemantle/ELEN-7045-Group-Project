using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Account.Tests.DomainTypes;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Account.Tests
{
    public partial class AccountStatus_identity : FeatureFixture
    {
        private AccountStatus status1;
        private AccountStatus status2;
        private bool areEqual;


        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = status1.Equals(status2);
        }

        private void another_account_status(AccountStatus status)
        {
            status2 = status;
        }

        private void account_status(AccountStatus status)
        {
            status1 = status;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
