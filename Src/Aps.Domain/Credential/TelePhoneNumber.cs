using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Credential
{
    public struct TelePhoneNumber : IIdentificationField
    {
        private readonly string _telephonenumber;

        public TelePhoneNumber(string telephonenumber)
        {
            Guard.ThatParameterNotNullOrEmpty(telephonenumber, "Telephone Number");
            if (!Validator.PhoneIsValid(telephonenumber))
            {
                throw new DomainException("Phone Number Credential", "Invalid Telephone Number");
            }

            this._telephonenumber = telephonenumber;

        }


        public override string ToString()
        {
            return _telephonenumber;
        }
    }
}
