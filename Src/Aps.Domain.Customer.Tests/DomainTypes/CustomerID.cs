namespace Aps.Domain.Customer.Tests.DomainTypes
{
    public struct CustomerID
    {
        private readonly IIdentificationField ID;

        public CustomerID(IIdentificationField id)
        {
            Guard.ThatValueTypeNotDefaut(id, "id");
            ID = id;
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}