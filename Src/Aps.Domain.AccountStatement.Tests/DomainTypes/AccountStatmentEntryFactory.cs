using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements.Tests
{
    public class AccountStatmentEntryFactory
    {
        public AccountStatmentEntry Build(ScrapeResultDataPair dataPair, AccountStatmentEntryType entryType)
        {
            var type = entryType.GetDataType();

            return new AccountStatmentEntry(9, new Money(20));
        }
    }
}