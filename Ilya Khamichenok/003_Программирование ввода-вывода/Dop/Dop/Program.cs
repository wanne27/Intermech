namespace Dop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++) 
            {
               Directory.CreateDirectory((@"D:\\" + @"Folder_" + i.ToString()));
            }

            for(int i = 0; i < 100; i++) 
            {
                Directory.Delete((@"D:\\" + @"Folder_" + i.ToString()));
            }
        }
    }
}
