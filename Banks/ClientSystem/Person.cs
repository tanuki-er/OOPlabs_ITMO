namespace Banks.ClientSystem
{
    public class Person
    {
        protected Person(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }

        public string Address { get => AddressPrivate; set => AddressPrivate = value; }
        public string Passport { get => PassportPrivate; set => PassportPrivate = value; }
        protected string Name { get => FirstName + " " + SecondName; }
        private string FirstName { get; set; }
        private string SecondName { get; set; }
        private string AddressPrivate { get; set; }
        private string PassportPrivate { get; set; }
    }
}