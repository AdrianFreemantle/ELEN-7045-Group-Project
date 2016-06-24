using System;
using System.Collections.Generic;
using System.Linq;
using Aps.Domain.AccountStatements.StatementEntryDataConverters;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public class StatmentEntryFactory
    {
        private readonly ICollection<IDataTypeConverter> dataTypeConverters;

        public StatmentEntryFactory()
        {
            dataTypeConverters = new IDataTypeConverter[]
            {
                new BalanceDataTypeConverter(),
                new TextDataTypeConverter(), 
                new KilowattHourTypeConverter(), 
                new PercentageTypeConverter(), 
                new DurationTypeConverter(), 
                new DateDataTypeConverter(), 
                new MonthDataTypeConverter(), 
            };
        }

        public StatmentEntryFactory(ICollection<IDataTypeConverter> dataTypeConverters)
        {
            Guard.ThatParameterNotNullOrEmpty(dataTypeConverters, "dataTypeConverters");
        }

        public StatmentEntry Build(StatmentEntryType entryType, ScrapeResultDataPair dataPair)
        {
            Guard.ThatValueTypeNotDefaut(dataPair, "dataPair");
            Guard.ThatValueTypeNotDefaut(entryType, "entryType");

            IDataTypeConverter converter = GetDataTypeConverter(entryType);

            return BuildAccountStatmentEntry(entryType, dataPair, converter);
        }

        private static StatmentEntry BuildAccountStatmentEntry(StatmentEntryType entryType, ScrapeResultDataPair dataPair, IDataTypeConverter converter)
        {
            IAccountStatementEntryData accountStatementEntryData = converter.ConvertToStatementEntryDataType(dataPair);
            int id = NumericValue.Parse(dataPair.Id).ToInt32();
            StatmentEntryId entryId = new StatmentEntryId(id);
            return new StatmentEntry(entryId, entryType, accountStatementEntryData);
        }

        private IDataTypeConverter GetDataTypeConverter(StatmentEntryType entryType)
        {
            StatementEntryDataType type = entryType.GetDataType();

            IDataTypeConverter converter = dataTypeConverters.SingleOrDefault(c => c.StatementEntryDataType == type);

            if (converter == null)
                throw new Exception(); //todo change the exception type

            return converter;
        }
    }
}