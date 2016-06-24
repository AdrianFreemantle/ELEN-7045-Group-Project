namespace Aps.Domain.Customers
{
    public struct CustomerName
    {
        private readonly string name;
        private readonly string surname;

        public CustomerName(string name, string surname)
        {
            Guard.ThatParameterNotNullOrEmpty(name,"name");
            Guard.ThatParameterNotNullOrEmpty(surname, "surname");

            this.name = name;
            this.surname = surname;
        }

        public CustomerName updateName(string newname)
        {
            return new CustomerName(newname,surname);
        }
        public CustomerName updateSurName(string newsurname)
        {
            return new CustomerName(name, newsurname);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", name, surname);
        }
    }
}