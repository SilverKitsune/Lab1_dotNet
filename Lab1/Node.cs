namespace List
{
    class Node<T>
    {
        public T data { get; internal set; }
        public Node<T> next;
        public Node(T data)
        {
            this.data = data;
        }
    }
}