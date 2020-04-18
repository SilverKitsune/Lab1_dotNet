using System;

namespace Lab1
{
    class Node<T> : IComparable<Node<T>> where T : IComparable, new()
    {
        public T data { get; internal set; }
        public Node<T> next;
        public Node(T data)
        {
            this.data = data;
        }

        public int CompareTo(Node<T> other)
        {
            return data.CompareTo(other.data);
        }
    }
}