namespace Aps.Domain.AccountStatement.Tests.DomainTypes
{
    public class AccountStatement 
    {
        private readonly AccountStatementId id;

        public AccountStatement(AccountStatementId id)
        {
            this.id = id;
        }

        public bool Equals(AccountStatementId other)
        {
            return id.Equals(other);
        }

        public bool Equals(AccountStatement other)
        {
            if (other == null)
                return false;

            return Equals(other.id);
        }
    }
}