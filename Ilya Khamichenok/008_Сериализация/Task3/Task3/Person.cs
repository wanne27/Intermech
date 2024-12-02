using System.Xml.Serialization;

namespace Task3
{
    public class Person
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person()
        {
            Name = "Fin";
            Age = 25;
        }
    }
}
