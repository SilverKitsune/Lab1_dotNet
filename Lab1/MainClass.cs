using System;

namespace Lab1
{
    public static class MainClass
    {
        static void Main(String[] args)
        {
            CheckList();
            //CheckTree();
        }

        private static void CheckList()
        {
            //var size = Console.ReadLine();
            var list = new LinkedList<int>(1);//Convert.ToInt32(size));
            list.Add(4);
            list.Add(3);
            list.Add(5);
            list.Add(2);
            
            list.Output();
            
            list.Sort();
            
            list.Output();
            list.Add(9);
            list.Output();
            
            /*list.Output();
            list.Remove(0);
            list.Output();
            list.Remove(11);
            list.Output();
            list.Add(10);
            list.Output();
            list.Reverse();
            list.Output();*/
        }

        private static void CheckTree()
        {
            var binaryTree = new Tree<int>();
        
            binaryTree.Add(8);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(1);
            binaryTree.Add(6);
            binaryTree.Add(4);
            binaryTree.Add(7);
            binaryTree.Add(14);
            binaryTree.Add(16);

            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(3);
            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(8);
            binaryTree.PrintTree();

            Console.ReadLine();
        }
    }
}