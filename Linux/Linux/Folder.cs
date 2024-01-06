using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux
{
    internal class Folder
    {
        public string Name { get; set; }
        public LinkedList<File> value;
        public LinkedList<Folder> children;
        public Folder parent;
    }
}
