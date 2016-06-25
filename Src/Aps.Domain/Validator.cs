using System.Text.RegularExpressions;

namespace Aps.Domain
{
    class Validator
    {
        static Regex ValidEmailRegex = CreateValidEmailRegex();

        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        static Regex ValidPhoneNoRegex = CreateValidPhoneRegex();

        private static Regex CreateValidPhoneRegex()
        {
            string validPhonePattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            
            return new Regex(validPhonePattern, RegexOptions.IgnoreCase);
        }

        internal static bool PhoneIsValid(string telephoneNumber)
        {
            bool PhoneValid = ValidPhoneNoRegex.IsMatch(telephoneNumber);

            return PhoneValid;
        }
    }
}
