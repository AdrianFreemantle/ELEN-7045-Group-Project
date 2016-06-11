using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Account.Tests.Tests.DomainTypes;
using LightBDD;
using Shouldly;

namespace Aps.Domain.Account.Tests.Tests
{
    public partial class Account_identity : FeatureFixture
    {
        private AccountId id1;
        private AccountId id2;
        private bool areEqual;


        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = id1.Equals(id2);
        }

        private void another_account_id(AccountId id)
        {
            id2 = id;
        }

        private void account_id(AccountId id)
        {
            id1 = id;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
