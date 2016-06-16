using System;
using Aps.Domain.Credential;

namespace Aps.Domain.Common
{
    public struct DateOfBirth : IIdentificationField
    {
        private readonly DateTime _dateofbirth;

        public DateOfBirth(DateTime dateofbirth)
        {
            Guard.ThatValueTypeNotDefaut(dateofbirth, "Date Of Birth");

            if (dateofbirth > DateTime.Now)
            {
                throw new DomainException("Date Of Birth Credential", "Invalid Date Of Birth Passed");
            }

            this._dateofbirth = dateofbirth;
        }
        //To-Do Add encryption 
    }
}