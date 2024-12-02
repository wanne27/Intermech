using System.Xml.Serialization;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Donald", 68);
            var xmlSerializer = new XmlSerializer(typeof(Person));

            using(var fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, person);
            }
        }
    }
}
