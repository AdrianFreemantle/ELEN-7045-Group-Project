using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.StatementEntryDataConverters
{
    public class TextDataTypeConverter : IDataTypeConverter
    {
        public StatementEntryDataType StatementEntryDataType { get { return StatementEntryDataType.Text; } }

        public IAccountStatementEntryData ConvertToStatementEntryDataType(ScrapeResultDataPair dataPair)
        {
            return new TextValue(dataPair.FieldValue);
        }
    }
}