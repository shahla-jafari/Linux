using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux
{
    internal class Tree
    {
        public string Name { get; set; }
        public Folder root;
        public Tree() { root = null; }

        public int Hight(Folder root)
        {
            if (root == null)
                return 0;
            ListNode<Folder> temp = root.children.first();
            int high = 0;
            while (temp != null)
            {
                if (Hight(temp.value) > high)
                    high = Hight(temp.value);
                temp = temp.next;
            }
            return high + 1;
        }



    }
}
