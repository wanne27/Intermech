namespace TaskDop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FactoryWorker worker = new FactoryWorker();
            worker.DoWork();
        }
    }
}
