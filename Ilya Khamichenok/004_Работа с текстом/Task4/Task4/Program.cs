namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"..\\Checklist.txt";
            var strList = new List<string>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    strList.Add(sr.ReadLine());
                }
            }

            ShowCheckList.Show(strList);
        }
    }
}
 