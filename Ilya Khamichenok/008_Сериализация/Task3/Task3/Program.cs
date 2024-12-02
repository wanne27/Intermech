using System.Xml.Serialization;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var xmlSerializer = new XmlSerializer(typeof(Person));

            using (var fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                var person = xmlSerializer.Deserialize(fs) as Person;
                Console.WriteLine(person.Name + " " + person.Age);
            }
        }
    }
}
