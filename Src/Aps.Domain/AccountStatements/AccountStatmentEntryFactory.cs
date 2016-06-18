using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Aps.Domain.AccountStatements.DataTypeConverters;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public class AccountStatmentEntryFactory
    {
        private readonly ICollection<IDataTypeConverter> dataTypeConverters;

        public AccountStatmentEntryFactory()
        {
            dataTypeConverters = new IDataTypeConverter[]
            {
                new BalanceDataTypeConverter(),
                new TextDataTypeConverter(), 
            };
        }

        public AccountStatmentEntryFactory(ICollection<IDataTypeConverter> dataTypeConverters)
        {
            Guard.ThatParameterNotNullOrEmpty(dataTypeConverters, "dataTypeConverters");
        }

        public AccountStatmentEntry Build(AccountStatmentEntryType entryType, ScrapeResultDataPair dataPair)
        {
            Guard.ThatValueTypeNotDefaut(dataPair, "dataPair");
            Guard.ThatValueTypeNotDefaut(entryType, "entryType");

            IDataTypeConverter converter = GetDataTypeConverter(entryType);

            return BuildAccountStatmentEntry(entryType, dataPair, converter);
        }

        private static AccountStatmentEntry BuildAccountStatmentEntry(AccountStatmentEntryType entryType, ScrapeResultDataPair dataPair, IDataTypeConverter converter)
        {
            IFormattable formattableValue = converter.ConvertToFormattableValue(dataPair);
            int id = NumericValue.Parse(dataPair.Id).ToInt32();
            return new AccountStatmentEntry(id, entryType, formattableValue);
        }

        private IDataTypeConverter GetDataTypeConverter(AccountStatmentEntryType entryType)
        {
            DataType type = entryType.GetDataType();

            IDataTypeConverter converter = dataTypeConverters.SingleOrDefault(c => c.DataType == type);

            if (converter == null)
                throw new Exception(); //todo change the exception type

            return converter;
        }
    }
}