using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class File
    {
        public string Name;
        public string Size;
        public string Path;

        public File(string name, string size, string path)
        {
            Name = name;
            Size = size;
            Path = path;
        }
    }
}
