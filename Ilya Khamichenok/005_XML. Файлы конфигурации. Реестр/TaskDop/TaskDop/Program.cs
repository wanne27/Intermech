using System.Xml.Linq;

namespace TaskDop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument xDocument = new XDocument(new XElement("MyContacts",
                    new XElement("Contact",
                        new XElement("name", "Ilya"),
                        new XAttribute("TelephoneNumber", "+375291153432")),
                    new XElement("Contact",
                        new XElement("name", "Valera"),
                        new XAttribute("TelephoneNumber", "+37529111111")),
                    new XElement("Contact",
                        new XElement("name", "Dyadya Vova"),
                        new XAttribute("TelephoneNumber", "+375337777777"))));
            xDocument.Save("TelephoneBook.xml");
        }
    }
}
