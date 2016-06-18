using System;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.DataTypeConverters
{
    public class TextDataTypeConverter : IDataTypeConverter
    {
        public DataType DataType { get { return DataType.Text; } }

        public IFormattable ConvertToFormattableValue(ScrapeResultDataPair dataPair)
        {
            return new TextValue(dataPair.FieldValue);
        }
    }
}