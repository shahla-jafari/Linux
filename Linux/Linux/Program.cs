using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Tree> trees = new LinkedList<Tree>();
            Tree root = new Tree();
            trees.addLast(new ListNode<Tree>(root));
            Tree tree = root;
            Folder thisFolder = new Folder();
            thisFolder = tree.root;
            while (true)
            {
                string input = Console.ReadLine();
                string[] st = input.Split(' ');
                string vorudi = st[0];
                switch(vorudi)
                {
                    case "su":
                        {
                            string name = st[1];
                            ListNode<Tree> temp = trees.first();
                            bool f = false;
                            while (temp != null)
                            {
                                if (temp.value.Name == name)
                                {
                                    tree = temp.value;
                                    Console.WriteLine("You are in " + name + " tree.");
                                    f = true;
                                    break;
                                }
                            }
                            if (f == false)
                                Console.WriteLine(name + " not found! you are in " + tree.Name + " tree.");
                            break;
                        }
                    case "pwd":
                        {
                            LinkedList<string> masir = new LinkedList<string>();
                            while (thisFolder != null)
                            {
                                masir.addFirst(new ListNode<string>(thisFolder.Name));
                                thisFolder = thisFolder.parent;
                            }
                            ListNode<string> output = masir.first();
                            while (output != null)
                                Console.WriteLine(output.value + "/");
                            break;
                        }
                    case "mkdir":
                        {
                            string masir = "";
                            int x;
                            if (st[1][0] != '/')
                                x = 6;
                            else
                            {
                                x = 7;
                                thisFolder = tree.root;
                            }

                            for (int i = x; i < input.Length; i++)
                            {
                                masir += input[i];
                            }

                            string[] address = masir.Split('/');
                            for (int i = 0; i < address.Length - 1; i++)
                            {
                                bool find = false;
                                ListNode<Folder> temp = thisFolder.children.first();
                                while (temp != null)
                                {
                                    if (temp.value.Name == address[i])
                                    {
                                        thisFolder = temp.value;
                                        find = true;
                                        break;
                                    }
                                    temp = temp.next;
                                }
                                if (!find)
                                {
                                    Console.WriteLine(address[i] + " not found!");
                                    break;
                                }
                            }
                            Folder addedF = new Folder();
                            addedF.Name = address[address.Length - 1];
                            thisFolder.children.addFirst(new ListNode<Folder>(addedF));
                            break;
                        }
                    case "touch":
                        {
                            File file = new File(st[1]);
                            thisFolder.value.addFirst(new ListNode<File>(file));
                            Console.WriteLine("file added!");
                            break;
                        }
                    case "rmdir":
                        {
                            string masir = "";
                            int x;
                            if (st[1][0] != '/')
                                x = 6;
                            else
                            {
                                x = 7;
                                thisFolder = tree.root;
                            }

                            for (int i = x; i < input.Length; i++)
                            {
                                masir += input[i];
                            }

                            string[] address = masir.Split('/');
                            for (int i = 0; i < address.Length - 1; i++)
                            {
                                bool find = false;
                                ListNode<Folder> temp = thisFolder.children.first();
                                while (temp != null)
                                {
                                    if (temp.value.Name == address[i])
                                    {
                                        thisFolder = temp.value;
                                        find = true;
                                        break;
                                    }
                                    temp = temp.next;
                                }
                                if (!find)
                                {
                                    Console.WriteLine(address[i] + " not found!");
                                    break;
                                }
                            }
                            ListNode<Folder> f = thisFolder.children.first();
                            while (f != null)
                            {
                                if (f.value.Name == address[address.Length - 1])
                                {
                                    thisFolder.children.remove(f);
                                }
                            }
                            break;
                        }
                    case "cp":
                        {
                            string masir1 = "";
                            for (int i = 1; i < st[1].Length; i++)
                            {
                                masir1 += st[1][i];
                            }
                            thisFolder = tree.root;
                            Folder copyfromHere = tree.root;
                            string[] address1 = masir1.Split('/');
                            for (int i = 0; i < address1.Length - 1; i++)
                            {
                                bool find = false;
                                ListNode<Folder> temp = copyfromHere.children.first();
                                while (temp != null)
                                {
                                    if (temp.value.Name == address1[i])
                                    {
                                        copyfromHere = temp.value;
                                        find = true;
                                        break;
                                    }
                                    temp = temp.next;
                                }
                                if (!find)
                                {
                                    Console.WriteLine(address1[i] + " not found!");
                                    break;
                                }
                            }


                            string masir2 = "";
                            for (int i = 1; i < st[1].Length; i++)
                            {
                                masir2 += st[1][i];
                            }
                            Folder copyHere = tree.root;
                            string[] address2 = masir2.Split('/');
                            for (int i = 0; i < address2.Length; i++)
                            {
                                bool find = false;
                                ListNode<Folder> temp = copyHere.children.first();
                                while (temp != null)
                                {
                                    if (temp.value.Name == address2[i])
                                    {
                                        thisFolder = temp.value;
                                        copyHere = temp.value;
                                        find = true;
                                        break;
                                    }
                                    temp = temp.next;
                                }
                                if (!find)
                                {
                                    Console.WriteLine(address2[i] + " not found!");
                                    break;
                                }
                            }



                            bool m = false;
                            ListNode<Folder> tp = copyfromHere.children.first();
                            while (tp != null)
                            {
                                if (tp.value.Name == address1[address1.Length - 1])
                                {
                                    copyHere.children.addFirst(new ListNode<Folder>(tp.value));
                                    Console.WriteLine("Folder copied.");
                                    m = true;
                                    break;
                                }
                                tp = tp.next;
                            }
                            if (!m)
                            {
                                bool mm = false;
                                ListNode<File> tp2 = copyfromHere.value.first();
                                while (tp2 != null)
                                {
                                    if (tp2.value.Name == address1[address1.Length - 1])
                                    {
                                        copyHere.value.addFirst(new ListNode<File>(tp2.value));
                                        Console.WriteLine("File copied.");
                                        mm = true;
                                        break;
                                    }
                                    tp2 = tp2.next;
                                }
                                if (!mm)
                                    Console.WriteLine("File or folder with this name was not found!");
                            }


                            break;
                        }
                    case "mv":
                        {
                            string masir1 = "";
                            for (int i = 1; i < st[1].Length; i++)
                            {
                                masir1 += st[1][i];
                            }
                            thisFolder = tree.root;
                            Folder copyfromHere = tree.root;
                            string[] address1 = masir1.Split('/');
                            for (int i = 0; i < address1.Length - 1; i++)
                            {
                                bool find = false;
                                ListNode<Folder> temp = copyfromHere.children.first();
                                while (temp != null)
                                {
                                    if (temp.value.Name == address1[i])
                                    {
                                        copyfromHere = temp.value;
                                        find = true;
                                        break;
                                    }
                                    temp = temp.next;
                                }
                                if (!find)
                                {
                                    Console.WriteLine(address1[i] + " not found!");
                                    break;
                                }
                            }


                            string masir2 = "";
                            for (int i = 1; i < st[1].Length; i++)
                            {
                                masir2 += st[1][i];
                            }
                            Folder copyHere = tree.root;
                            string[] address2 = masir2.Split('/');
                            for (int i = 0; i < address2.Length; i++)
                            {
                                bool find = false;
                                ListNode<Folder> temp = copyHere.children.first();
                                while (temp != null)
                                {
                                    if (temp.value.Name == address2[i])
                                    {
                                        thisFolder = temp.value;
                                        copyHere = temp.value;
                                        find = true;
                                        break;
                                    }
                                    temp = temp.next;
                                }
                                if (!find)
                                {
                                    Console.WriteLine(address2[i] + " not found!");
                                    break;
                                }
                            }



                            bool m = false;
                            ListNode<Folder> tp = copyfromHere.children.first();
                            while (tp != null)
                            {
                                if (tp.value.Name == address1[address1.Length - 1])
                                {
                                    copyHere.children.addFirst(new ListNode<Folder>(tp.value));
                                    copyfromHere.children.remove(tp);
                                    Console.WriteLine("Folder cut.");
                                    m = true;
                                    break;
                                }
                                tp = tp.next;
                            }
                            if (!m)
                            {
                                bool mm = false;
                                ListNode<File> tp2 = copyfromHere.value.first();
                                while (tp2 != null)
                                {
                                    if (tp2.value.Name == address1[address1.Length - 1])
                                    {
                                        copyHere.value.addFirst(new ListNode<File>(tp2.value));
                                        copyfromHere.value.remove(tp2);
                                        Console.WriteLine("File cut.");
                                        mm = true;
                                        break;
                                    }
                                    tp2 = tp2.next;
                                }
                                if (!mm)
                                    Console.WriteLine("File or folder with this name was not found!");
                            }


                            break;
                        }
                    case "ls":
                        {
                            ListNode<Folder> folders = thisFolder.children.first();
                            while(folders != null)
                            {
                                Console.WriteLine(folders.value.Name);
                                folders = folders.next;
                            }
                            ListNode<File> files = thisFolder.value.first();
                            while(files != null)
                            {
                                Console.WriteLine(files.value.Name);
                                files = files.next;
                            }
                            break;
                        }
                    case "cd":
                        {
                            if (st[1] == "..")
                            {
                                if (thisFolder != tree.root)
                                    thisFolder = thisFolder.parent;
                            }
                            else
                            {
                                bool find = false;
                                ListNode<Folder> temp = thisFolder.children.first();
                                while (temp != null)
                                {
                                    if (temp.value.Name == st[1])
                                    {
                                        thisFolder = temp.value;
                                        find = true;
                                        break;
                                    }
                                    temp = temp.next;
                                }
                                if (!find)
                                {
                                    Console.WriteLine(st[1] + " not found!");
                                    break;
                                }
                            }
                            break;
                        }
                    case "find":
                        {
                            break;
                        }
                    case "sp":
                        {
                            string masir1 = "";
                            for (int i = 1; i < st[1].Length; i++)
                            {
                                masir1 += st[1][i];
                            }
                            thisFolder = tree.root;
                            Folder BB1 = tree.root;
                            string[] address1 = masir1.Split('/');
                            for (int i = 0; i < address1.Length - 1; i++)
                            {
                                bool find = false;
                                ListNode<Folder> temp = BB1.children.first();
                                while (temp != null)
                                {
                                    if (temp.value.Name == address1[i])
                                    {
                                        BB1 = temp.value;
                                        find = true;
                                        break;
                                    }
                                    temp = temp.next;
                                }
                                if (!find)
                                {
                                    Console.WriteLine(address1[i] + " not found!");
                                    break;
                                }
                            }


                            string masir2 = "";
                            for (int i = 1; i < st[1].Length; i++)
                            {
                                masir2 += st[1][i];
                            }
                            Folder BB2 = tree.root;
                            string[] address2 = masir2.Split('/');
                            for (int i = 0; i < address2.Length - 1; i++)
                            {
                                bool find = false;
                                ListNode<Folder> temp = BB2.children.first();
                                while (temp != null)
                                {
                                    if (temp.value.Name == address2[i])
                                    {
                                        thisFolder = temp.value;
                                        BB2 = temp.value;
                                        find = true;
                                        break;
                                    }
                                    temp = temp.next;
                                }
                                if (!find)
                                {
                                    Console.WriteLine(address2[i] + " not found!");
                                    break;
                                }
                            }


                            Folder valedayeBB1 = BB1;
                            Folder valedayeBB2 = BB2;
                            Folder valedMoshtarak = tree.root;
                            bool ft = false;
                            while (valedayeBB1 != null)
                            {
                                valedayeBB2 = BB2;
                                while (valedayeBB2 != null)
                                {
                                    if (valedayeBB2 == valedayeBB1)
                                    {
                                        valedMoshtarak = valedayeBB1;
                                        ft = true;
                                        break;
                                    }
                                    valedayeBB2 = valedayeBB2.parent;
                                }
                                if (ft)
                                    break;
                                valedayeBB1 = valedayeBB1.parent;
                            }

                            Console.WriteLine(valedMoshtarak.Name);

                            break;
                        }
                    case "sz":
                        {
                            string masir = "";
                            thisFolder = tree.root;
                            for (int i = 3; i < input.Length; i++)
                            {
                                masir += input[i];
                            }

                            string[] address = masir.Split('/');
                            for (int i = 0; i < address.Length; i++)
                            {
                                bool find = false;
                                ListNode<Folder> temp = thisFolder.children.first();
                                while (temp != null)
                                {
                                    if (temp.value.Name == address[i])
                                    {
                                        thisFolder = temp.value;
                                        find = true;
                                        break;
                                    }
                                    temp = temp.next;
                                }
                                if (!find)
                                {
                                    Console.WriteLine(address[i] + " not found!");
                                    break;
                                }
                            }
                            Console.WriteLine("size of directories : " + thisFolder.children.size);
                            Console.WriteLine("size of files : " + thisFolder.value.size);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error!");
                            break;
                        }
                }
            }
        }
    }
}
