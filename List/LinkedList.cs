using System;
using System.Net.Sockets;

namespace List
{
    public class LinkedList
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine();
            LinkedList list = new LinkedList(Convert.ToInt32(size));
            list.Output();
            list.Remove(0);
            list.Output();
            list.Remove(11);
            list.Output();
            list.Add(10);
            list.Output();
            list.Reverse();
            list.Output();
        }
        
        private Node begin;
        private Node end;
        private int count;
        private bool IsEmpty => count == 0;

        private LinkedList(int size)
        {
            if (size <= 0) return;
            int num = -1;
            for (int i = 0; i < size; i++)
                Add(++num);
        }

        public void Add(int data)
        {
            Node node = new Node(data);
            if (begin == null)
                begin = node;
            else
                end.next = node;
            end = node;
            count++;
        }

        public bool Remove(int data)
        {
            if (IsEmpty) return false;
            Node current = begin;
            Node previous = null;
            bool isFound = false;
            
            for (int i = 0; i < count; i++)
            {
                if (current.data == data)
                {
                    isFound = true;
                    break;
                }
                previous = current;
                current = current.next;
            }

            if (!isFound) return false;
            
            if (previous == null)
            {
                if (current.next == null)
                {
                    begin = null; 
                    end = null;
                }
                else
                    begin = current.next;
            }
            else
            {
                if (current.next == null)
                {
                    previous.next = null;
                    end = previous;
                }
                else
                    previous.next = current.next; 
            }
            count--;
            return true;
        }

        public void Output()
        {
            if(IsEmpty) Console.Write("Empty");
            Node node = begin;
            while(node != null)
            {
                Console.Write("{0} ", node.data);
                node = node.next;
            }
            Console.Write('\n');
        }

        public void Reverse()
        {
            if (count < 2) return;
            Node previousNode, currentNode = begin;
            begin = end;
            end = currentNode;
            previousNode = currentNode; 
            currentNode = currentNode.next;
            if (currentNode.next == null)
            {
                currentNode.next = previousNode;
                previousNode.next = null;
            }
            else
            {
                previousNode.next = null;
                while (currentNode != null)
                {
                    Node nextNode = currentNode.next;
                    currentNode.next = previousNode;
                    previousNode = currentNode;
                    currentNode = nextNode;
                }
            }
        }
        
    }
    
}