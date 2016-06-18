using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Common;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public struct AccountStatmentEntryMapping
    {
        public AccountStatmentEntryType AccountStatmentEntryType { get; private set; }
        public string FieldName { get; private set; }

        public AccountStatmentEntryMapping(AccountStatmentEntryType accountStatmentEntryType, string fieldName) : this()
        {
            AccountStatmentEntryType = accountStatmentEntryType;
            FieldName = fieldName;
        }
    }
}
