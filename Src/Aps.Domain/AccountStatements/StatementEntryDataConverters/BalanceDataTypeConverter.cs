using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.StatementEntryDataConverters
{
    public class BalanceDataTypeConverter : IDataTypeConverter
    {
        public StatementEntryDataType StatementEntryDataType { get { return StatementEntryDataType.Balance;} }

        public IAccountStatementEntryData ConvertToStatementEntryDataType(ScrapeResultDataPair dataPair)
        {
            NumericValue value = NumericValue.Parse(dataPair.FieldValue);
            return Balance.FromAmount(value.ToDecimal());
        }
    }
}