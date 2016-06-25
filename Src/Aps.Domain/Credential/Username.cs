using System;

namespace Aps.Domain.Credential
{
    public struct UserName : IIdentificationField
    {
        private readonly string _userName;

        public UserName(string userName)
        {
            Guard.ThatParameterNotNullOrEmpty(userName, "User Name");



            Console.WriteLine("Username  : "  + userName);

            if (userName.Length > 100)
            {
                throw new DomainException("User Name Credential", "Invalid User Name passed");
            }            
    
            this._userName = userName;
        }

        public override string ToString()
        {
            return _userName;
        }
    }
}