using System.IO.Compression;
using System.Text;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var searchFile = new SearchFile().SearchPath("D:\\", "content.txt");

            using (FileStream fstream = new FileStream(searchFile, FileMode.Open))
            {
                var buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                var textFromFile = Encoding.Default.GetString(buffer);

                Console.WriteLine($"Текст из файла: {textFromFile}");
            }

            var bytes = File.ReadAllBytes(searchFile);

            using (FileStream fs = new FileStream( "D:\\newContent.txt", FileMode.OpenOrCreate))
            {
                using (GZipStream zipStream = new GZipStream(fs, CompressionMode.Compress, false))
                {
                    zipStream.Write(bytes, 0, bytes.Length);
                }
            }

        }
    }
}
