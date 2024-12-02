namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var carFactory = new CarFactory();
            var toyFactory = new ToyFactory();

            toyFactory.Work();
            carFactory.Work();
        }
    }
}
