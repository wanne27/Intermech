namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Users\\Im\\Desktop\\text.txt";
            var txt = "asdasd";

            File.WriteAllText(path, txt);

            string readTxt = File.ReadAllText(path);

            Console.WriteLine(readTxt);
        }
    }
}
