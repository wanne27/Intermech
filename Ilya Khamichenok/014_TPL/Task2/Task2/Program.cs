namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Factory.StartNew(() => {
                Parallel.Invoke(
                Print,
                () => Square(5));
            });

            Thread.Sleep(3000);
            Console.WriteLine("Закончился мэйн поток");
        }

        static void Print()
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
        }

        static void Square(int n)
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"Результат {n * n}");
        }
    }
}
