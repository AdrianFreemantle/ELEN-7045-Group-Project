namespace Aps.Domain.Credential
{
    public class IdentificationField : ICredential
    {
        private string _field;

        private IdentificationField(string field)
        {
            this._field = field;
        }
    }
}
