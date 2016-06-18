using System.Linq;
using System.Net.Configuration;
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

        internal static bool CreditCardIsValid(string creditcardNumber)
        {
            if (creditcardNumber.Length != 16)
            {
                return false;
            }
            if (!creditcardNumber.All(c => c >= '0' && c <= '9'))
            {
                return false;
            }  

            return true;
        }

        internal static bool CcvIsValid(string ccvNumber)
        {
            if (ccvNumber.Length != 3)
            {
                return false; 
            }

            if (!ccvNumber.All(c => c >= '0' && c <= '9'))
            {
                return false;
            }

            return true; 
        }

        internal static bool IdentityNumberIsValid(string identityNumber)
        {
            if (identityNumber.Length != 13)
            {
                return false;
            }
            if (!identityNumber.All(c => c >= '0' && c <= '9'))
            {
                return false;
            }  

            return true;
        }

        internal static bool EmailIsValid(string emailAddress)
        {
            bool isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }

        internal static bool CredentialIsValid(string credential)
        {
            if (string.IsNullOrEmpty(credential))
            {
                return false;
            }

            if (credential.Length > 100)
            {
                return false;
            }

            return true;
        }

        internal static bool NameVoIsValid(string namevo)
        {
            if (string.IsNullOrEmpty(namevo))
            {
                return false;
            }

            if (namevo.Length > 100)
            {
                return false; 
            }
            return true;
        }

        internal static bool SurnameVoIsValid(string surnamevo)
        {
            if (string.IsNullOrEmpty(surnamevo))
            {
                return false;
            }

            if (surnamevo.Length > 100)
            {
                return false;
            }
            return true;
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
