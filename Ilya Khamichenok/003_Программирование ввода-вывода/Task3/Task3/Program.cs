using System.Text.RegularExpressions;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "D:\\text.txt";
            var pattern = @"\b(в|на|с|по|к|о|без|из|для|при|через|над|под|между|среди|и|от)\b";
            var stringList  = new List<string>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    stringList.Add(sr.ReadLine());
                }
            }
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                foreach(var str in stringList)
                {
                   sw.WriteLine(Regex.Replace(str, pattern, "ГАВ"));
                }   
            }
        }
    }
}
