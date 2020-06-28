using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string rootPath = @"/home/masayume/DATA/E/Temp/demon/unity/dotNET/03-FileSystemDemo/ConsoleUI/FileSystem";

            string[] dirs = Directory.GetDirectories(rootPath);
            foreach (string dir in dirs) 
            {
                Console.WriteLine(dir);
            }

            Console.ReadLine();
        }
    }
}
