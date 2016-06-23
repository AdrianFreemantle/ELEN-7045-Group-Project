using System;
using Aps.Domain.Account.Tests.DomainTypes;
using Aps.Domain.Common;
using Aps.Domain.Credential;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Account.Tests
{
    [TestClass]
    [FeatureDescription(@"Equality checks and In-equality checks for Date Of Birth")]
    public partial class DateOfBirth_equality
    {
        [TestMethod]
        public void Two_DateOfBirth_credentials_with_the_same_Dates_are_equal()
        {
            IEncryptionService encryptionService = new Encryption();
            var first = new DateOfBirth(new DateTime(1980, 6, 16), encryptionService);
            var second = new DateOfBirth(new DateTime(1980, 6, 16), encryptionService);

            Runner.RunScenario(
            given => dateofBirth(first),
            and => another_dateofBirth(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_DateOfBirth_credentials_with_different_Dates_are_not_equal()
        {
            IEncryptionService encryptionService = new Encryption();
            var first = new DateOfBirth(new DateTime(1980, 6, 16), encryptionService);
            var second = new DateOfBirth(new DateTime(1980, 7, 16), encryptionService);

            Runner.RunScenario(
            given => dateofBirth(first),
            and => another_dateofBirth(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
