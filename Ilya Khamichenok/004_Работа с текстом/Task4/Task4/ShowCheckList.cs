using System.Globalization;
using System.Text.RegularExpressions;

namespace Task4
{
    public static class ShowCheckList
    {
        public static void Show(List<string> checkList)
        {
            var enUsCulture = CultureInfo.CreateSpecificCulture("en-US");
            var currentCulture = CultureInfo.CurrentUICulture;

            var dateRegex = new Regex(@"(0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[012])[.](19|20)\d\d");
            var belRubPattern = @"бел.руб\w*";
            var pricePattern = @"(\d+\.\d+)(?=бел\.руб)";

            foreach (string str in checkList)
            {
                if (dateRegex.IsMatch(str))
                {
                    Console.WriteLine(DateOnly.Parse(str).ToString(enUsCulture));
                }
                else
                {
                    var matchesPrice = Regex.Match(str, pricePattern);
                    var price = Double.Parse(matchesPrice.Groups[1].Value.Replace(".", ","));
                    var line = Regex.Replace(str, pricePattern, Math.Round(ExchangeCoure.BynToUsd(price), 2).ToString(enUsCulture));

                    Console.WriteLine(Regex.Replace(line, belRubPattern, "$"));
                }
            }

            Console.WriteLine();

            foreach (string str in checkList)
            {
                Console.WriteLine(str.ToString(currentCulture));
            }
        }
    }
}
