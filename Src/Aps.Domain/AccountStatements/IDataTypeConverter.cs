using System;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public interface IDataTypeConverter
    {
        DataType DataType { get; }

        IFormattable ConvertToFormattableValue(ScrapeResultDataPair dataPair);
    }
}