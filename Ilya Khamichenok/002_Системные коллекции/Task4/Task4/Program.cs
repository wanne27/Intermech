namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orderDicCollection = new OrderedDictionaryCollection<string, int>();
            var orderDicCollection2 = new OrderedDictionaryCollection<string, int>();

            orderDicCollection.Add("a", 1);
            orderDicCollection.Add("b", 2);
            orderDicCollection.Add("c", 3);
            orderDicCollection.Add("d", 4);
            orderDicCollection2.Add("a2", 1);
            orderDicCollection2.Add("b", 2);
            orderDicCollection2.Add("c", 3);
            orderDicCollection2.Add("d", 4);

            var orderDicCollectionComparer = new OrderedDictionaryCollectionComparer<string, int>();
            var compare = orderDicCollectionComparer.Equals(orderDicCollection, orderDicCollection2);

            Console.WriteLine(compare);

            orderDicCollection2.Insert(2, "f", 5);

            try
            {
                orderDicCollection.Remove("c");
                orderDicCollection.Update("a", 4);

                Console.WriteLine(orderDicCollection.GetByIndex(2));
                Console.WriteLine(orderDicCollection.GetValueByKey("a"));
                Console.WriteLine(orderDicCollection.Contains("c"));

                foreach (var item in orderDicCollection)
                {
                    Console.WriteLine(item);
                }

                orderDicCollection.Clear();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}
