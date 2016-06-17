using System;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public class AccountStatmentEntryFactory
    {
        public AccountStatmentEntry Build(AccountStatmentEntryType entryType, ScrapeResultDataPair dataPair)
        {
            Guard.ThatValueTypeNotDefaut(dataPair, "dataPair");
            Guard.ThatValueTypeNotDefaut(entryType, "entryType");

            DataType type = entryType.GetDataType();

            switch (type)
            {
                    case DataType.Balance:
                    return BuildBlanceEntry(entryType, dataPair);

                default:
                    throw new Exception(); //todo change the exception type
            }
        }

        private AccountStatmentEntry BuildBlanceEntry(AccountStatmentEntryType entryType, ScrapeResultDataPair dataPair)
        {
            NumericValue value = NumericValue.Parse(dataPair.FieldValue);
            int id = NumericValue.Parse(dataPair.Id).ToInt32();
            var balance = Balance.FromAmount(value.ToDecimal());
            return new AccountStatmentEntry(id, entryType, balance);
        }
    }
}