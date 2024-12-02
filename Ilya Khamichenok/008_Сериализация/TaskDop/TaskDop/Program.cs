using System.Runtime.Serialization.Formatters.Soap;

namespace TaskDop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Ilya", 48);

            var formatter = new SoapFormatter();

            using(var fs = new FileStream("person.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
            }

        }
    }
}
