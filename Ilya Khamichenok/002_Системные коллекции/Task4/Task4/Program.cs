namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orderDicCollection = new OrderedDictionaryCollection<string, int>();

            orderDicCollection.Add("a", 1);
            orderDicCollection.Add("b", 2);
            orderDicCollection.Add("c", 3);
            orderDicCollection.Add("d", 4);

            try
            {
                orderDicCollection.Remove();
                orderDicCollection.Update("a", 4);

                Console.WriteLine(orderDicCollection.GetByIndex(0));

                foreach (var item in orderDicCollection)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine(orderDicCollection.GetValueByKey("a"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}
