using System;
using System.Runtime.Serialization;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.AccountStatements.Tests
{
    public partial class Current_account_statement : FeatureFixture
    {
        private Exception error = null;


        public void when_doing_stuff()
        {
            try
            {
                //do my thing here
            }
            catch (Exception e)
            {
                error = e;
            }
        }

        public void then_error()
        {
            Assert.IsTrue(error != null);
        }


    }
}