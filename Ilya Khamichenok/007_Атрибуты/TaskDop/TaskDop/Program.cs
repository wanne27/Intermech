using TaskDop.Employee;

namespace TaskDop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager();
            var isAccess = Authentication.TryAccess(manager, Access.lvl3);
            Console.WriteLine(isAccess);
        }
    }
}
