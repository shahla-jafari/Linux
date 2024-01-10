using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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


        public Folder findfolder (ListNode<Folder> folder, string name, string search)
        {
            Folder result = null;
            if (search == "dfs")
            {
                ListNode<Folder> temp = folder;
                while (temp != null)
                {
                    if (DFS(temp, name) != null)
                        return DFS(temp, name).value;
                    temp = temp.next;
                }
            }
            else if (search == "bfs")
            {
                LinkedList<Folder> list = new LinkedList<Folder>();
                ListNode<Folder> temp = folder;
                while (temp!=null)
                {
                    ListNode<Folder> add = new ListNode<Folder>(temp.value);
                    list.addLast(add);
                    temp = temp.next;
                }

                while (!list.isEmpty())
                {
                    ListNode<Folder> check = list.removeFirst();
                    AddChild(check, list);
                    if (check.value.Name == name)
                        return check.value;
                }

            }
            return result;
        }


        public Folder findfile(ListNode<Folder> folder, string name, string search)
        {
            Folder result = null;
            if (search == "dfs")
            {

            }
            else if (search == "bfs")
            {
                LinkedList<Folder> list = new LinkedList<Folder>();
                ListNode<Folder> temp = folder;
                while (temp != null)
                {
                    ListNode<Folder> add = new ListNode<Folder>(temp.value);
                    list.addLast(add);
                    temp = temp.next;
                }

                while (!list.isEmpty())
                {
                    ListNode<Folder> check = list.removeFirst();
                    AddChild(check, list);
                    ListNode<File> file = check.value.value.first();
                    while (file != null)
                    {
                        if (file.value.Name == name)
                            return check.value;
                        file = file.next;
                    }
                }
            }
            return result;
        }



        public ListNode<Folder> DFS(ListNode<Folder> node , string name)
        {
            if (node != null)
            {
                if (node.value.Name == name)
                    return node;
                ListNode<Folder> temp = node.value.children.first();
                while (temp != null)
                {
                    if (DFS(temp, name) != null)
                        return DFS(temp, name);
                    temp = temp.next;
                }
            }
            return null;
        }


        public ListNode<Folder> DFSFile(ListNode<Folder> node, string name)
        {
            if (node != null)
            {
                ListNode<File> file = node.value.value.first();
                while (file != null)
                {
                    if (file.value.Name == name)
                        return node;
                    file = file.next;
                }
                ListNode<Folder> temp = node.value.children.first();
                while (temp != null)
                {
                    if (DFSFile(temp, name) != null)
                        return DFSFile(temp, name);
                    temp = temp.next;
                }
            }
            return null;
        }


        public void AddChild (ListNode<Folder> node, LinkedList<Folder> list)
        {
            ListNode<Folder> temp = node.value.children.first();
            while (temp != null)
            {
                list.addLast(temp);
                temp = temp.next;
            }
        }

    }
}
