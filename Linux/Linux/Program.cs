using System;
using System.CodeDom.Compiler;
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
            Tree tree = new Tree();
            Folder thisFolder = new Folder();
            thisFolder = tree.root;
            string account = "root";
            while (true)
            {
                try
                {
                    Console.WriteLine();
                    string input = Console.ReadLine();
                    string[] st = input.Split(' ');
                    string vorudi = st[0];
                    switch (vorudi)
                    {
                        case "su":
                            {
                                string name = st[1];
                                if (name == "root" || name == "administrator")
                                {
                                    account = name;
                                    Console.WriteLine("you are in " + account + " account.");
                                }
                                else
                                    Console.WriteLine(name + " not found! you are in " + account + " tree.");
                                break;
                            }
                        case "pwd":
                            {
                                LinkedList<string> masir = new LinkedList<string>();
                                Folder temp = thisFolder;
                                while (temp != null)
                                {
                                    masir.addFirst(new ListNode<string>(temp.Name));
                                    temp = temp.parent;
                                }
                                ListNode<string> output = masir.first();
                                while (output != null)
                                {
                                    Console.Write(output.value + "/");
                                    output = output.next;
                                }
                                Console.WriteLine();
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
                                bool ff = true;
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
                                        ff = false;
                                        break;
                                    }
                                }
                                if (!ff)
                                    break;
                                Folder addedF = new Folder();
                                addedF.parent = thisFolder;
                                addedF.Name = address[address.Length - 1];
                                thisFolder.children.addFirst(new ListNode<Folder>(addedF));
                                thisFolder = addedF;
                                Console.WriteLine(addedF.Name + " added.");
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
                                        Console.WriteLine(f.value.Name + " removed.");
                                        break;
                                    }
                                    f = f.next;
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
                                for (int i = 1; i < st[2].Length; i++)
                                {
                                    masir2 += st[2][i];
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
                                        tree.Copy(copyHere, tp.value);
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
                                for (int i = 1; i < st[2].Length; i++)
                                {
                                    masir2 += st[2][i];
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
                                        tp.value.parent = copyHere;
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
                                ListNode<File> files = thisFolder.value.first();

                                if (folders == null && files == null)
                                    Console.WriteLine("folder is empty");

                                while (folders != null)
                                {
                                    Console.WriteLine(folders.value.Name);
                                    folders = folders.next;
                                }
                                while (files != null)
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
                                string masir = "";
                                for (int i = 1; i < st[1].Length; i++)
                                {
                                    masir += st[1][i];
                                }
                                thisFolder = tree.root;
                                ListNode<Folder> thisnode = tree.root.children.first();
                                string[] address = masir.Split('/');
                                for (int i = 0; i < address.Length; i++)
                                {
                                    bool find = false;
                                    ListNode<Folder> temp = thisFolder.children.first();
                                    while (temp != null)
                                    {
                                        if (temp.value.Name == address[i])
                                        {
                                            thisnode = temp;
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

                                if (st[2] == "d")
                                {
                                    Folder result = tree.findfolder(thisnode, st[3], st[4]);
                                    if (result != null)
                                    {
                                        thisFolder = result;
                                        Console.WriteLine("You are in " + result.Name + " folder.");
                                    }
                                    else
                                        Console.WriteLine(st[3] + " not found!");
                                }
                                else if (st[2] == "f")
                                {
                                    Folder result = tree.findfile(thisnode, st[3], st[4]);
                                    if (result != null)
                                    {
                                        thisFolder = result;
                                        Console.WriteLine(result.Name + " found. You are in " + result.Name + " folder");
                                    }
                                    else
                                        Console.WriteLine(st[3] + " not found!");
                                }

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

                                ListNode<Folder> tep = BB1.children.first();
                                while (tep != null)
                                {
                                    if (tep.value.Name == address1[address1.Length - 1])
                                    {
                                        BB1 = tep.value;
                                        break;
                                    }
                                    tep = tep.next;
                                }


                                string masir2 = "";
                                for (int i = 1; i < st[2].Length; i++)
                                {
                                    masir2 += st[2][i];
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

                                ListNode<Folder> tempfolder = BB2.children.first();
                                while (tep != null)
                                {
                                    if (tempfolder.value.Name == address2[address2.Length - 1])
                                    {
                                        BB2 = tempfolder.value;
                                        break;
                                    }
                                    tempfolder = tempfolder.next;
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
                                for (int i = 4; i < input.Length; i++)
                                {
                                    masir += input[i];
                                }

                                string[] address = masir.Split('/');
                                if (address[0] != "")
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
                catch (Exception)
                {
                    Console.WriteLine("Error.");
                }
            }
        }
    }
}
