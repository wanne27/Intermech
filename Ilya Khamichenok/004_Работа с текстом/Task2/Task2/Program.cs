using System.Net;
using System.Text.RegularExpressions;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var html = new WebClient().DownloadString("https://www.21vek.by/services/contacts.html");
            var regexURL = new Regex(@"https?://[a-zA-Z0-9.-]+(?:/[^\s]*)?");
            var regexNumber = new Regex(@"\+375\s\d{2}\s\d-\d{3}-\d{3}");
            var regexEmail = new Regex(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");

            var matchesURL = regexURL.Matches(html).Select(m => m.Value).ToList();
            var matchesNumber = regexNumber.Matches(html).Select(m => m.Value).ToList();
            var matchesEmail = regexEmail.Matches(html).Select(m => m.Value).ToList();

            using (TextWriter tw = new StreamWriter("D:\\SavedList.txt"))
            {
                foreach (var matche in matchesURL)
                {
                    tw.WriteLine(matche);
                }

                foreach (var matche in matchesNumber)
                {
                    tw.WriteLine(matche);
                }

                foreach (var matche in matchesEmail)
                {
                    tw.WriteLine(matche);
                }
            }
        }
    }
}

