using System;
using System.IO;
using System.Text;

namespace _01LocalData
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "EgyikKonyvtar";

            Console.WriteLine($"Ennek a relatív könyvtárnak: {path} ");
            Console.WriteLine($"ez az abszolút útja: {Path.GetFullPath(path)}");

            Console.Write($"A temporális könyvtár: {Path.GetTempPath()}");
            

            var tempFile = Path.GetTempFileName();

            Console.WriteLine($"A temporális file: {tempFile}");

            Console.WriteLine($"A random fájl név: {Path.GetRandomFileName()}");

            Console.WriteLine($"GetFileNameWithoutExtension: {Path.GetFileNameWithoutExtension(tempFile)}");
            Console.WriteLine($"GetExtension: {Path.GetExtension(tempFile)}");
            Console.WriteLine($"GetDirectoryName: {Path.GetDirectoryName(tempFile)}");

            var dirName = Path.Combine("egy", "ketto", "harom");


            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            Console.WriteLine($"Ennek a relatív könyvtárnak: {dirName} ");
            Console.WriteLine($"ez az abszolút útja: {Path.GetFullPath(dirName)}");

            var fileName = "test.txt";

            File.WriteAllText(fileName, string.Format("nyilván szöveget {0} tudok írni, illetve speciális karaktereket {1}, ASCII {2}, unicode karakter {3}, karkatertömb szöveg: {4}"
                , "mindenképpen"
                , Environment.NewLine, (char)113
                , Convert.ToChar(115)
                , '\u0027'
                ,Encoding.ASCII.GetChars(new byte[] { 35,36})
                ),Encoding.UTF8);


            var info = new FileInfo(fileName);

            Console.WriteLine($"Ez egy könyvtár: {info.Attributes.HasFlag(FileAttributes.Directory)}");

            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                using (var sr = new StreamReader(fs, Encoding.UTF8)) {

                    while (!sr.EndOfStream)
                    {
                       
                        var text = sr.ReadLine();
                        Console.WriteLine(text);
                    }
                    
                }
            }

                Console.ReadLine();
        }
    }
}
