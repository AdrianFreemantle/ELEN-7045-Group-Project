using System;
using Aps.Domain.Scrap.Tests.DomainTypes;
using Aps.Domain.Common;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Scrap.Tests
{
    [TestClass]
    [FeatureDescription(@"A data pair must contain valid data on creation")]
    public partial class ScrapResultDataPair_Data_Collection
    {
        [TestMethod]
        public void A_data_pair_with_a_null_id_is_invalid()
        {
            //Arrange,Act and Assert

            Runner.RunScenario(
                given => an_id(null),
                and => a_field_value("abc"),
                and => a_field_name("Person"),
                when => creating_data_pair(),
                then => exception_thrown());
            
        }

        [TestMethod]
        public void A_data_pair_with_a_null_fieldname_is_invalid()
        {
            //Arrange,Act and Assert

            Runner.RunScenario(
                given => an_id("1"),
                and => a_field_value(null),
                and => a_field_name("Person"),
                when => creating_data_pair(),
                then => exception_thrown());

        }

        [TestMethod]
        public void A_data_pair_with_a_null_fieldvalue_is_invalid()
        {
            //Arrange,Act and Assert

            Runner.RunScenario(
                given => an_id("1"),
                and => a_field_value("abc"),
                and => a_field_name(null),
                when => creating_data_pair(),
                then => exception_thrown());

        }

        [TestMethod]
        public void A_data_pair_with_an_empty_id_is_invalid()
        {
            //Arrange,Act and Assert

            Runner.RunScenario(
                given => an_id(""),
                and => a_field_value("abc"),
                and => a_field_name("Person"),
                when => creating_data_pair(),
                then => exception_thrown());

        }

        [TestMethod]
        public void A_data_pair_with_an_empty_fieldname_is_invalid()
        {
            //Arrange,Act and Assert

            Runner.RunScenario(
                given => an_id("1"),
                and => a_field_value(""),
                and => a_field_name("Person"),
                when => creating_data_pair(),
                then => exception_thrown());

        }

        [TestMethod]
        public void A_data_pair_with_an_empty_fieldvalue_is_invalid()
        {
            //Arrange,Act and Assert

            Runner.RunScenario(
                given => an_id("1"),
                and => a_field_value("abc"),
                and => a_field_name(""),
                when => creating_data_pair(),
                then => exception_thrown());

        }

    }

}
