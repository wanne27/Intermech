using System.Xml.Serialization;

namespace Task2
{
    [Serializable]
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
