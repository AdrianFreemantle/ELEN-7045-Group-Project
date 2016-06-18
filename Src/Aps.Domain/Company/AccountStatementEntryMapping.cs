using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Common;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public struct AccountStatmentEntryMapping : IEquatable<AccountStatmentEntryMapping>
    {
        public AccountStatmentEntryType AccountStatmentEntryType { get; private set; }
        public string FieldName { get; private set; }

        public AccountStatmentEntryMapping(AccountStatmentEntryType accountStatmentEntryType, string fieldName) : this()
        {
            AccountStatmentEntryType = accountStatmentEntryType;
            FieldName = fieldName;
        }

        public bool Equals(AccountStatmentEntryMapping other)
        {
            return AccountStatmentEntryType.Equals(other.AccountStatmentEntryType) && FieldName.Equals(other.FieldName);
        }
    }
}
