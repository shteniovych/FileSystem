using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path:");
            string path = Console.ReadLine();

            List<string> dirs = new List<string>();
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                dirs.Add(file);
            }

            Dir root = new Dir("");
            foreach (string dir in dirs)
            {
                root.FindOrCreate(dir, dir);
            }
      
            string output = JsonConvert.SerializeObject(root);
            Console.WriteLine(output);


            Console.ReadKey();
        }
    }
}
