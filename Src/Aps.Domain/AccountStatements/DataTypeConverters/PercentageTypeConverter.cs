using System;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.DataTypeConverters
{
    public class PercentageTypeConverter : IDataTypeConverter
    {
        public DataType DataType { get { return DataType.Percentage; } }

        public IFormattable ConvertToFormattableValue(ScrapeResultDataPair dataPair)
        {
            NumericValue value = NumericValue.Parse(dataPair.FieldValue);
            return Percentage.FromAmount(value.ToDecimal());
        }
    }
}