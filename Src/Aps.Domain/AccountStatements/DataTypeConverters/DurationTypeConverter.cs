using System;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.DataTypeConverters
{
    public class DurationTypeConverter : IDataTypeConverter
    {
        public DataType DataType { get { return DataType.Duration; } }

        public IFormattable ConvertToFormattableValue(ScrapeResultDataPair dataPair)
        {
            return new Duration(dataPair.FieldValue);
        }
    }
}