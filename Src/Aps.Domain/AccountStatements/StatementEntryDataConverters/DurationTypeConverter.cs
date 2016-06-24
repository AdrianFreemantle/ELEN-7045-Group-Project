using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.StatementEntryDataConverters
{
    public class DurationTypeConverter : IDataTypeConverter
    {
        public StatementEntryDataType StatementEntryDataType { get { return StatementEntryDataType.Duration; } }

        public IAccountStatementEntryData ConvertToStatementEntryDataType(ScrapeResultDataPair dataPair)
        {
            return new Duration(dataPair.FieldValue);
        }
    }
}