using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux
{
    internal class TreeNode<T>
    {
        public T value;
        public LinkedList<TreeNode<T>> children;
        public TreeNode<T> parent;

        public TreeNode(T item)
        {
            value = item;
        }
    }
}
