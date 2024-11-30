using System.Xml;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlTextReader reader = new XmlTextReader("TelephoneBook.xml");

            while (reader.Read())
            {
                if(reader.NodeType == XmlNodeType.Element)
                {
                    while (reader.MoveToNextAttribute())
                    {
                        Console.WriteLine(reader.Value);
                    }
                }
            }
        }
    }
}
