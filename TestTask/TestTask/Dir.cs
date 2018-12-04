using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Dir
    {
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public Dictionary<string, Dir> Dirs { get; set; }
        public HashSet<File> Files { get; set; }

        public Dir(string name)
        {
            Name = name;
            Dirs = new Dictionary<string, Dir>();
            Files = new HashSet<File>();
        }

        public Dir FindOrCreate(string path, string fullPath, bool mightBeFile = true)
        {
            int i = path.IndexOf('\\');
            if (i > -1)
            {
                Dir dir = FindOrCreate(path.Substring(0, i),fullPath, false);
                FileInfo info = new FileInfo(fullPath);
                dir.DateCreated = info.CreationTime.ToString("dddd, dd MMMM yyyy");
                return dir.FindOrCreate(path.Substring(i + 1), fullPath, true);
            }

            if (path == "") return this;

            if (mightBeFile && path != "." && path.Contains("."))
            {
                FileInfo info = new FileInfo(fullPath);
                Files.Add(new File(path, info.Length.ToString() + " B", fullPath));
                return this;
            }

            Dir child;
            if (Dirs.ContainsKey(path))
            {
                child = Dirs[path];
            }
            else
            {
                child = new Dir(path);
                FileInfo info = new FileInfo(fullPath);
                child.DateCreated = info.CreationTime.ToString("dddd, dd MMMM yyyy");
                Dirs.Add(path, child);
            }
            return child;
        }
    }
}
