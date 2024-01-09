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
        public Tree()
        {
            root = new Folder();
            root.Name = "";
            root.parent = null;
            root.value = new LinkedList<File>();
            root.children = new LinkedList<Folder>();
        }

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


        public void Copy(Folder root2 , Folder copyBeshe)
        {
            Folder folder = new Folder();
            folder.Name = copyBeshe.Name;
            folder.parent = root2;
            root2.children.addFirst(new ListNode<Folder>(folder));

            // copy value
            ListNode<File> file = copyBeshe.value.first();
            while (file != null)
            {
                ListNode<File> node = new ListNode<File>(file.value);
                folder.value.addFirst(node);
                file = file.next;
            }

            //copy children
            ListNode<Folder> childfoldre = copyBeshe.children.first();
            while (childfoldre != null)
            {
                Copy(folder, childfoldre.value);
                childfoldre = childfoldre.next;
            }
        }


    }
}
