using System;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.DataTypeConverters
{
    public class MonthDataTypeConverter : IDataTypeConverter
    {
        public DataType DataType { get { return DataType.Month; } }

        public IAccountStatementEntryData ConvertToStatementEntryDataType(ScrapeResultDataPair dataPair)
        {
            return new Month(dataPair.FieldValue);
        }
    }
}