namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<int, double>();
            var list = new List<(int, double)>();
            var accountCollection = new AccountCollection();

            dictionary.Add(12, 25.1);
            list.Add((1, 23.423));
            accountCollection.Add(4, 2.43);
            accountCollection.Add(5, 2.43);
            accountCollection.Add(1254, 35.113);
            accountCollection.Add(215, 12.323);

            var account = accountCollection.GetByDouble(2.43);
            var amount = accountCollection.GetByInt(215);

            foreach (var item in account)
            {
                Console.WriteLine(item);
            }

            foreach (var item in amount)
            {
                Console.WriteLine(item);
            }

            foreach (var item in accountCollection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
