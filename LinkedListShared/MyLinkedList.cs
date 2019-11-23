using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedListShared
{
    public class MyLinkedList<T> : IEnumerable<MyLinkedListNode<T>>
    {
        public MyLinkedListNode<T> Head { get; set; }

        public MyLinkedList(MyLinkedListNode<T> headNode)
        {
            Head = headNode;
        }

        public MyLinkedList(IEnumerable<T> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if (items.Count() == 0)
                return;

            foreach (var item in items)
                AddLast(new MyLinkedListNode<T>() { Value = item });
        }


        public IEnumerator<MyLinkedListNode<T>> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        public void AddLast(MyLinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            if (Head == null)
            {
                Head = node;
                return;
            }

            var current = Head;
            while (current.Next != null)
                current = current.Next;

            current.Next = node;
        }

        public void Remove(MyLinkedListNode<T> item)
        {
            if (Head == item)
            {
                Head = item.Next;
                return;
            }

            var current = Head;
            while (current.Next != null)
            {
                if (current.Next == item)
                {
                    current.Next = current.Next.Next;
                    return;
                }

                current = current.Next;
            }

        }

        public MyLinkedList<T> Concat(MyLinkedList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (Head == null)
            {
                Head = list.Head;
                return this;
            }

            var current = Head;
            while (current.Next != null)
                current = current.Next;

            current.Next = list.Head;

            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public MyLinkedListNode<T> NodeAt(int v)
        {
            var current = Head;
            var counter = 0;
            while (current != null)
            {
                if (counter == v)
                    return current;

                counter++;

                current = current.Next;
            }

            throw new ArgumentException("Index is out of range");
        }

        public MyLinkedList<T> Clone()
        {
            var first = new MyLinkedListNode<T>(Head.Value);
            var last = first;
            var current = Head.Next;
            while (current != null)
            {
                var cloned = new MyLinkedListNode<T>(current.Value);
                last.Next = cloned;
                last = cloned;

                current = current.Next;
            }
            return new MyLinkedList<T>(first);
        }

        public override string ToString()
        {
            if (Head == null)
                return string.Empty;

            MyLinkedListNode<T> p1 = Head, p2 = Head;

            //Detect loop in list using Floyd's Tortoise and Hare
            //if string has no loops print normaly
            while (true)
            {
                p1 = p1.Next;
                p2 = p2?.Next?.Next;

                if (p2 == null)
                {
                    //list has no loop so print it normaly
                    return string.Join(" -> ", this.Select(x => x.Value).ToList());
                }

                if (p1 == p2)
                    break;
            }

            //detect loopnode
            p1 = Head;
            while (true)
            {
                p1 = p1.Next;
                p2 = p2.Next;
                if (p1 == p2)
                    break;
            }

            //find looped node and when we encounter it second time end printing there...
            var sb = new StringBuilder();
            //use p1 as loopNode and p2 as iterator
            var loopCounter = 0;
            p2 = Head;
            while (true)
            {
                if (p2 == p1)
                {
                    loopCounter++;
                    sb.Append(p2.ToString() + "(loop)");
                }
                else
                {
                    sb.Append(p2.ToString());
                }

                if (loopCounter == 2) break;

                p2 = p2.Next;
                if (p2 != null) sb.Append(" -> ");

            }

            return sb.ToString();
        }
    }
}
