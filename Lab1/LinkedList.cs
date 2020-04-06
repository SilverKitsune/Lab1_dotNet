using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    /**Односвязный список*/
    public class LinkedList<T>: IEnumerable<T> where T : IComparable, new()
    {
        private Node<T> _begin;
        private Node<T> _end;
        private int _count;
        
        private bool IsEmpty => _count == 0;

        public LinkedList(int size)
        {
            if (size <= 0) return;
            
            for (int i = 0; i < size; i++)
                Add(new T());
        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (_begin == null)
                _begin = node;
            else
                _end.next = node;
            _end = node;
            _count++;
        }

        public bool Remove(T data)
        {
            if (IsEmpty) return false;
            Node<T> current = _begin;
            Node<T> previous = null;
            bool isFound = false;
            
            for (int i = 0; i < _count; i++)
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
                    _begin = null; 
                    _end = null;
                }
                else
                    _begin = current.next;
            }
            else
            {
                if (current.next == null)
                {
                    previous.next = null;
                    _end = previous;
                }
                else
                    previous.next = current.next; 
            }
            _count--;
            return true;
        }

        public void Output()
        {
            if(IsEmpty) Console.Write("Empty");
            Node<T> node = _begin;
            while(node != null)
            {
                Console.Write("{0} ", node.data);
                node = node.next;
            }
            Console.Write('\n');
        }

        public void Reverse()
        {
            if (_count < 2) return;
            Node<T> previousNode, currentNode = _begin;
            _begin = _end;
            _end = currentNode;
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

        public void Sort()
        {
            Node<T> newBegin = null;
            Node<T> newEnd = _begin;
            while (_begin != null)
            {
                Node<T> node = _begin;
                if (_begin.CompareTo(newEnd) > 0)
                    newEnd = _begin;
                _begin = _begin.next;
                if (newBegin == null || node.CompareTo(newBegin) < 0)
                {
                    node.next = newBegin;
                    newBegin = node;
                }
                else
                {
                    Node<T> current= newBegin;
                    while (current.next != null && node.CompareTo(current.next) >= 0)
                    {
                        current = current.next;
                    }
                    node.next = current.next;
                    current.next = node;
                }
            }
            _begin = newBegin;
            _end = newEnd;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _begin;
 
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