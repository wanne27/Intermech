namespace TaskDop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var bigdData = new BigData())
            {
                Console.WriteLine("BigData object is in use.");
            }

            Console.WriteLine("BigData object disposed.");
        }
    }
}
