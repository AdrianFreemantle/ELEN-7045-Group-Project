using System;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public interface IDataTypeConverter
    {
        StatementEntryDataType StatementEntryDataType { get; }
        IAccountStatementEntryData ConvertToStatementEntryDataType(ScrapeResultDataPair dataPair);
    }
}