namespace TaskDop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var flag = true;

            while (flag)
            {
                Console.Write("Input Login: ");
                var login = Console.ReadLine();

                if (SignUpValidation.ValidateLogin(login))
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Use latin characters!");
                }
            }

            flag = true;

            while (flag)
            {
                Console.Write("Input Password: ");
                var password = Console.ReadLine();

                if (SignUpValidation.VerifyPassword(password))
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Use latin characters and digitals");
                }
            }
        }
    }
}
