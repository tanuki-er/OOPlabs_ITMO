namespace Banks.ClientSystem
{
    public class Person
    {
        protected Person(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }

        private string FirstName { get; set; }
        private string SecondName { get; set; }
        private string address { get; set; }
        public string Address { get => address; set => address = value; }
        private string passport { get; set; }
        public string Passport { get => passport; set => passport = value; }
    }
}