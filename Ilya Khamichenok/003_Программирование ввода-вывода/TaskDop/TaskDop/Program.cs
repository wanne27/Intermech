using System.Text.RegularExpressions;

namespace TaskDop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var loginPattern = @"^[a-zA-Z]+$";
            var passwordPattern = @"^(?=.*\d)(?=.*[a-zA-Z])(?!.*\s).*$";
            var login = "";
            var password = "";

            while (true)
            {
                Console.Write("Input Login: ");
                login = Console.ReadLine();

                if (!Regex.IsMatch(login, loginPattern))
                {
                    Console.WriteLine("Use latin characters!");
                }
                else
                {                    
                    break;
                }                
            }

            while (true)
            {
                Console.Write("Input Password: ");
                password = Console.ReadLine();

                if (!Regex.IsMatch(password, passwordPattern))
                {
                    Console.WriteLine("Use latin characters and digitals");
                }
                else
                {
                    break;
                }
            }

        }
    }
}
