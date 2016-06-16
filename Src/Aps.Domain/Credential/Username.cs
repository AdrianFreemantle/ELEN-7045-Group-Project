namespace Aps.Domain.Credential
{
    public struct UserName : IIdentificationField
    {
        private readonly string _userName;

        private UserName(string userName)
        {
            Guard.ThatParameterNotNullOrEmpty(userName, "User Name");

            if (Validator.CredentialIsValid(userName))
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