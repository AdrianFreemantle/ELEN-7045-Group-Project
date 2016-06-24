namespace Aps.Domain.Customer.Tests.DomainTypes
{
    public struct CustomerId
    {
        private readonly IIdentificationField id;

        public CustomerId(IIdentificationField id)
        {
            Guard.ThatValueTypeNotDefaut(id, "id");
            this.id = id;
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }
}