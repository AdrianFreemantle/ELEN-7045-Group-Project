using System;

namespace Aps.Domain.Common
{
    internal struct DateOfBirth : ICredential
    {
        private DateTime _dateofbirth;

        private DateOfBirth(DateTime dateofbirth)
        {
            if (dateofbirth > DateTime.Now)
            {
                throw new DomainException("Date Of Birth Credential", "Invalid Date Of Birth Passed");
            }

            this._dateofbirth = dateofbirth;
        }
    }
}