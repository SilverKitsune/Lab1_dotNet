namespace Lab1
{
    /**Элемент*/
    class Node<T> where T : new()
    {
        public T data { get; internal set; }
        public Node<T> next;
        public Node(T data)
        {
            this.data = data;
        }
    }
}