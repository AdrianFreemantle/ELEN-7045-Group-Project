using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.StatementEntryDataConverters
{
    public class MonthDataTypeConverter : IDataTypeConverter
    {
        public StatementEntryDataType StatementEntryDataType { get { return StatementEntryDataType.Month; } }

        public IAccountStatementEntryData ConvertToStatementEntryDataType(ScrapeResultDataPair dataPair)
        {
            return new Month(dataPair.FieldValue);
        }
    }
}