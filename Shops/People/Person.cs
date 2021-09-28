namespace Shops.People
{
    public class Person 
    {
        private string PersonName { get; set; }
        private float Gold { get; set; }

        public Person(string personName)
        {
            PersonName = personName;
            Gold = 500;
        }

    }
}