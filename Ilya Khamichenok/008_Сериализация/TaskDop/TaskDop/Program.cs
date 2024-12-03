using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;

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

            var json = JsonSerializer.Serialize(person);

            using (var writer = new StreamWriter("person.json", false))
            {
                writer.WriteLineAsync(json);
            }
        }
    }
}
