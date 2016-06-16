namespace Aps.Domain.Common
{
    internal struct UserNameCredential  : ICredential
    {
        private string userNameCredential;

        private UserNameCredential(string userNameCredential)
        {
            this.userNameCredential  = userNameCredential ;
        }

        public bool IsValid()
        {
            if (userNameCredential.Length > 100)
                return false;
            
            return true;
        }
    }
}