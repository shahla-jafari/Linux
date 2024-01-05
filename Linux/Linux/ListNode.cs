using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux
{
    internal class ListNode<T>
    {
        public T value;
        public ListNode<T> next;

        public ListNode(T val, ListNode<T> next = null)
        {
            this.value = val;
            this.next = next;
        }
    }
}
