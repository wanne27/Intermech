namespace TaskDop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[1000000];
            var rand = new Random();

            Parallel.For(0, 100000, (i, state) =>
            {
                array[i] = rand.Next();
            });

            var oddNumbers = array.AsParallel().Where(i => i % 2 == 1);

            foreach ( var number in oddNumbers)
            {
                Console.WriteLine(number);
            }
        }        
    }
}
