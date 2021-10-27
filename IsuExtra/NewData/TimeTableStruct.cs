namespace IsuExtra.NewData
{
    public class TimeTableStruct
    {
        public TimeTableStruct(int number, string name)
        {
            Number = number;
            Name = name;
        }

        private int Number { get; set; }
        private string Name { get; set; }
    }
}