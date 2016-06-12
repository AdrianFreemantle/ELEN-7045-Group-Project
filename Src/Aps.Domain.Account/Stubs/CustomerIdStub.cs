namespace Aps.Domain.Account.Tests.Stubs
{
    public struct CustomerIdStub : ICustomerId
    {
        private readonly string customerId;

        public CustomerIdStub(string customerId)
        {
            this.customerId = customerId;
        }

        public override string ToString()
        {
            return customerId;
        }
    }
}