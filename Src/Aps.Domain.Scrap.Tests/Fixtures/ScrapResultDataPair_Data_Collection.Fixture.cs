using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Common;
using Aps.Domain.Scrap.Tests.DomainTypes;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Scrap.Tests
{
    public partial class ScrapResultDataPair_Data_Collection : FeatureFixture
    {

        private ScrapeResultDataPair dataPair;
        private Exception error;
        private string fieldName;
        private string fieldValue;
        private string id;

        void an_id(string id)
        {
            this.id = id;
        }

        void a_field_name(string fieldName)
        {
            this.fieldName = fieldName;
        }

        void a_field_value(string fieldValue)
        {
            this.fieldValue = fieldValue;
        }

        void creating_data_pair()
        {
            try
            {
                dataPair = new ScrapeResultDataPair(id, fieldName, fieldValue);
            }
            catch (Exception ex)
            {
                error = ex;
            }
        }

        void exception_thrown()
        {
            Assert.IsNotNull(error);
        }
    }
}
