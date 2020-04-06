using System;

namespace List
{
    public static class MainClass
    {
        static void Main(String[] args)
        {
            string size = Console.ReadLine();
            LinkedList<int> list = new LinkedList<int>(Convert.ToInt32(size));
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
    }
}