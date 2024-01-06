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
                            while (temp != null)
                            {
                                if (temp.value.Name == name)
                                {
                                    tree = temp.value;
                                    break;
                                }
                            }
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

                            break;
                        }
                    case "touch":
                        {
                            File file = new File(st[1]);
                            thisFolder.value.addFirst(new ListNode<File>(file));
                            break;
                        }
                    case "rmdir":
                        {
                            break;
                        }
                    case "cp":
                        {
                            break;
                        }
                    case "mv":
                        {
                            break;
                        }
                    case "ls":
                        {
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
