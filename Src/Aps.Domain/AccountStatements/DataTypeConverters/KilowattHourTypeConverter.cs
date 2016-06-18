using System;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.DataTypeConverters
{
    public class KilowattHourTypeConverter : IDataTypeConverter
    {
        public DataType DataType { get { return DataType.KilowattHour; } }

        public IFormattable ConvertToFormattableValue(ScrapeResultDataPair dataPair)
        {
            NumericValue value = NumericValue.Parse(dataPair.FieldValue);
            return KilowattHour.FromAmount(value.ToUInt32());
        }
    }
}