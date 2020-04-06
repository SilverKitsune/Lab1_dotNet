using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    /**Односвязный список*/
    public class LinkedList<T>: IEnumerable<T> where T : new()
    {
        private Node<T> begin;
        private Node<T> end;
        private int count;
        private bool IsEmpty => count == 0;

        public LinkedList(int size)
        {
            if (size <= 0) return;
            
            for (int i = 0; i < size; i++)
                Add(new T());
        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (begin == null)
                begin = node;
            else
                end.next = node;
            end = node;
            count++;
        }

        public bool Remove(T data)
        {
            if (IsEmpty) return false;
            Node<T> current = begin;
            Node<T> previous = null;
            bool isFound = false;
            
            for (int i = 0; i < count; i++)
            {
                if (current.data.Equals(data))
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
            Node<T> node = begin;
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
            Node<T> previousNode, currentNode = begin;
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
                    Node<T> nextNode = currentNode.next;
                    currentNode.next = previousNode;
                    previousNode = currentNode;
                    currentNode = nextNode;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = begin;
 
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
    
}