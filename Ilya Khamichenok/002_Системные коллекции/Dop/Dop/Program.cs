namespace Dop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sortedLicst = new SortedList<string, int>();
            sortedLicst.Add("C", 3);
            sortedLicst.Add("A", 1);
            sortedLicst.Add("D", 4);
            sortedLicst.Add("B", 2);

            foreach (var item in sortedLicst)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var desc = sortedLicst.Reverse();

            foreach(var item in desc)
            {
                Console.WriteLine(item);
            }
        }
    }
}
