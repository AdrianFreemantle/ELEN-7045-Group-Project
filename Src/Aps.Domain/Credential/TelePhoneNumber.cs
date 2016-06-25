using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aps.Domain.Credential
{
    public struct TelephoneNumber : IIdentificationField
    {
        private readonly string _telephonenumber;

        public TelephoneNumber(string telephonenumber)
        {
            Guard.ThatParameterNotNullOrEmpty(telephonenumber, "Telephone Number");

            Regex ValidPhoneNoRegex = CreateValidPhoneRegex();
            if (!ValidPhoneNoRegex.IsMatch(telephonenumber))
            {
                throw new DomainException("Phone Number Credential", "Invalid Telephone Number");
            }

            this._telephonenumber = telephonenumber;
        }

        public override string ToString()
        {
            return _telephonenumber;
        }

        private static Regex CreateValidPhoneRegex()
        {
            string validPhonePattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";

            return new Regex(validPhonePattern, RegexOptions.IgnoreCase);
        }
    }
}
