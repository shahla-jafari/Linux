using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux
{
    internal class LinkedList<T>
    {
        int _size;
        ListNode<T> head;
        ListNode<T> tail;

        public int size { get { return _size; } }
        public bool isEmpty()
        {
            if (_size == 0)
                return true;
            else
                return false;
        }

        public ListNode<T> first()
        {
            if (_size != 0)
                return head;
            else
                return null;
        }

        public ListNode<T> last()
        {
            if (_size != 0)
                return tail;
            else
                return null;
        }

        public void addFirst(ListNode<T> e)
        {
            if (_size == 0)
            {
                head = e;
                tail = e;
            }
            else
            {
                e.next = head;
                head = e;
            }
            _size++;
        }
        public void addLast(ListNode<T> e)
        {
            if (_size == 0)
            {
                head = e;
                tail = e;
            }
            else
            {
                tail.next = e;
                e.next = null;
                tail = e;
            }
            _size++;
        }

        public ListNode<T> removeFirst()
        {
            if (_size == 0)
                return null;
            else
            {
                ListNode<T> e = head;
                head = head.next;
                _size--;
                return e;
            }
        }

        public ListNode<T> remove(ListNode<T> e)
        {
            ListNode<T> pretemp = head;
            ListNode<T> temp = head.next;
            if (size == 0)
                return null;
            if (e == head)
                return removeFirst();
            else
            {
                while (temp != null)
                {
                    if (temp == e)
                    {
                        pretemp.next = temp.next;
                        _size--;
                        return temp;
                    }
                    pretemp = pretemp.next;
                    temp = temp.next;
                }
                return null;
            }
        }
    }
}
