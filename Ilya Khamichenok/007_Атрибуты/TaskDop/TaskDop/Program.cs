using TaskDop.Employee;

namespace TaskDop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager();
            var isAccess = Authentication.TryAccess(manager, 9);
            Console.WriteLine(isAccess);
        }
    }
}
