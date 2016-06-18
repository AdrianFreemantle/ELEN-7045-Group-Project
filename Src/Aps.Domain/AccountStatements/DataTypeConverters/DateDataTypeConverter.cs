using System;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.DataTypeConverters
{
    public class DateDataTypeConverter : IDataTypeConverter
    {
        public DataType DataType { get { return DataType.Date; } }

        public IFormattable ConvertToFormattableValue(ScrapeResultDataPair dataPair)
        {
            return new Date(DateTime.Parse(dataPair.FieldValue));
        }
    }
}