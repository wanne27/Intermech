using System.Net;
using System.Text.RegularExpressions;

namespace Task4
{
    public static class ExchangeCoure
    {
        private static string html;
        public static double BynToUsd(double byn)
        {
            return byn / GetUsdToBynCourse();
        }

        private static double GetUsdToBynCourse()
        {
            var regexUsdRate = @"<input[^>]*id=""nbrb_byn""[^>]*value=""([\d.]+)""";
            var matchesUsdRate = Regex.Match(html, regexUsdRate);

            return Double.Parse(matchesUsdRate.Groups[1].Value.Replace(".", ","));
        }

        static ExchangeCoure()
        {
            html = new WebClient().DownloadString("https://myfin.by/converter?utm_source=myfin&utm_medium=organic&utm_campaign=menu");
        }
    }
}
