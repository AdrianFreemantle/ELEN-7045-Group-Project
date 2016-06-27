using System;
using System.Collections.Generic;
using System.Linq;
using Aps.Domain.AccountStatements.StatementEntryDataConverters;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public class StatementEntryFactory
    {
        private readonly ICollection<IDataTypeConverter> dataTypeConverters;

        public StatementEntryFactory()
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

        public StatementEntryFactory(ICollection<IDataTypeConverter> dataTypeConverters)
        {
            Guard.ThatParameterNotNullOrEmpty(dataTypeConverters, "dataTypeConverters");
        }

        public StatementEntry Build(StatementEntryType entryType, ScrapeResultDataPair dataPair)
        {
            Guard.ThatValueTypeNotDefaut(dataPair, "dataPair");
            Guard.ThatValueTypeNotDefaut(entryType, "entryType");

            IDataTypeConverter converter = GetDataTypeConverter(entryType);

            return BuildAccountStatementEntry(entryType, dataPair, converter);
        }

        private static StatementEntry BuildAccountStatementEntry(StatementEntryType entryType, ScrapeResultDataPair dataPair, IDataTypeConverter converter)
        {
            IAccountStatementEntryData accountStatementEntryData = converter.ConvertToStatementEntryDataType(dataPair);
            int id = NumericValue.Parse(dataPair.Id).ToInt32();
            StatementEntryId entryId = new StatementEntryId(id);
            return new StatementEntry(entryId, entryType, accountStatementEntryData);
        }

        private IDataTypeConverter GetDataTypeConverter(StatementEntryType entryType)
        {
            StatementEntryDataType type = entryType.GetDataType();

            IDataTypeConverter converter = dataTypeConverters.SingleOrDefault(c => c.StatementEntryDataType == type);

            if (converter == null)
                throw new Exception(); //todo change the exception type

            return converter;
        }
    }
}