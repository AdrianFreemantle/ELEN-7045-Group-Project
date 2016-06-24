using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.StatementEntryDataConverters
{
    public class KilowattHourTypeConverter : IDataTypeConverter
    {
        public StatementEntryDataType StatementEntryDataType { get { return StatementEntryDataType.KilowattHour; } }

        public IAccountStatementEntryData ConvertToStatementEntryDataType(ScrapeResultDataPair dataPair)
        {
            NumericValue value = NumericValue.Parse(dataPair.FieldValue);
            return KilowattHour.FromAmount(value.ToUInt32());
        }
    }
}