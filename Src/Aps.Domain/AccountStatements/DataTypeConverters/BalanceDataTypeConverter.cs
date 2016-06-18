using System;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.DataTypeConverters
{
    public class BalanceDataTypeConverter : IDataTypeConverter
    {
        public DataType DataType { get { return DataType.Balance;} }

        public IFormattable ConvertToFormattableValue(ScrapeResultDataPair dataPair)
        {
            NumericValue value = NumericValue.Parse(dataPair.FieldValue);
            return Balance.FromAmount(value.ToDecimal());
        }
    }
}