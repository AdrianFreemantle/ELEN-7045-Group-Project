using System.Text.RegularExpressions;
using System;

namespace Aps.Domain.Credential
{
    public struct EmailAddress : IIdentificationField
    {
        private readonly string _address;

        public EmailAddress(string address): this()
        {
            Guard.ThatParameterNotNullOrEmpty(address, "Email Address"); 
            if (!EmailIsValid(address))
            {
                throw new DomainException("Email Credential", "Invalid Email Address passed");
            }

            this._address = address;
        }

        private Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }
        private bool EmailIsValid(string emailAddress)
        {
            Regex ValidEmailRegex = CreateValidEmailRegex();
            bool isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }

        public override string ToString()
        {

            Console.WriteLine("Inside Email struct");
            return _address;
            
        }
    }
}