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
                            for (int i = 0; i < address2.Length - 1; i++)
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


                            // کپی شدنش رو ننوشتم هنوز

                            break;
                        }
                    case "mv":
                        {
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
                            
                            break;
                        }
                    case "find":
                        {
                            break;
                        }
                    case "sp":
                        {
                            break;
                        }
                    case "sz":
                        {
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
