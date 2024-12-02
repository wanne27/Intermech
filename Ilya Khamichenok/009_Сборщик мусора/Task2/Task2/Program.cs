namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new string[10000000];

            Console.WriteLine("Укажите приемлимый объем физической памяти выделяемой для процесса в байтах");
            var size = Console.ReadLine();
            
            while(!long.TryParse(size, out var number))
            {
                Console.WriteLine("Укажите приемлимый объем физической памяти выделяемой для процесса в байтах");
                size = Console.ReadLine();
            }

            Notification.Initialize(long.Parse(size));
      
            for (int i = 0; i < 10000000; i++)
            {
                arr[i] = i.ToString("0000000000000000");
            }

            Thread.Sleep(10000);
        }
    }
}
