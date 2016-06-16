﻿using Aps.Domain.Credential;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Account.Tests
{
    public partial class Password_identity : FeatureFixture
    {
        private Password password1;
        private Password password2;
        private bool areEqual;


        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = password1.Equals(password2);
        }

        private void another_Password(Password password)
        {
            password2 = password;
        }

        private void password(Password password)
        {
            password1 = password;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
