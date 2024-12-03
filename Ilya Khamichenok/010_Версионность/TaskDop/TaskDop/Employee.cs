namespace TaskDop
{
    /// <summary>
    /// Базовый класс работник, имеет два метода, невиртуальный public метод и виртуальный protected метод
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Невиртуальный public метод, который будет вызывать виртуальный protected метод
        /// </summary>
        public void DoWork()
        {
            CoreDoWork();
        }

        protected virtual void CoreDoWork()
        {
            Console.WriteLine("Работник работает");
        }
    }
}
