namespace TaskDop
{
    /// <summary>
    /// Класс работника завода, наследуется от класса Employee, переопределяется метод CoreDoWork()
    /// </summary>
    public class FactoryWorker : Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }

        /// <summary>
        /// Конструктор FactoryWorker, по умолчанию задает значения Name = "Kolyan",  Age = 25
        /// </summary>
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
