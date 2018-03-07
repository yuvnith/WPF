using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class MyList2<T> : IMyList<T>
    {
        private Node head;
        private Node current;//This will have latest node
        public int Count;

        public MyList2()
        {
            head = new Node();
            current = head;
        }

        public void Add(T x)
        {
            Node newNode = new Node();
            newNode.Value = x;
            current.Next = newNode;
            current = newNode;
            Count++;
            
        }

        public T GetElementAt(int x)
        {
            int i = 0;
            Node curr = head.Next;
            Node prev = head;
            while (curr.Next != null)
            {
                if (i == x)
                return (T)curr.Value; 
                curr = curr.Next;
                i++;
            }           
            return default(T);            
        }

        public void Print()
        {
            Console.Write("Head ->");
            Node curr = head;
            while (curr.Next != null)
            {
                curr = curr.Next;
                Console.Write(curr.Value);
                Console.Write("->");
            }
            Console.Write("NULL");            
        }

        public bool Remove(T x)
        {
            Node curr = head.Next;
            Node prev = head;
            while (prev.Next != null)
            {
                
                if (curr.Value.ToString() == x.ToString())
                {
                    prev.Next = curr.Next;                    
                    return true;
                }
                prev = curr;
                 curr = curr.Next;
            }
            return false;
        }
    }

    public class Node
    {
        public Node Next;
        public object Value;
    }
    

}
