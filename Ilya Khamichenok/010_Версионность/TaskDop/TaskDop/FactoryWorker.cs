namespace TaskDop
{
    public class FactoryWorker : Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public FactoryWorker()
        {
            Name = "Kolyan";
            Age = 25;
        }

        protected override void CoreDoWork()
        {
            Console.WriteLine($"{Name} - {Age} лет работает за станком");
        }
    }
}
