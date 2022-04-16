using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraverseTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.Data = 1;
            tree.Left = new Tree<int> { Data = 2 };
            tree.Right = new Tree<int> { Data = 3 };
            tree.Left.Left = new Tree<int> { Data = 4 };
            tree.Left.Right = new Tree<int> { Data = 5 };

            DoTree(tree, (x) => Console.Write(x + " "));
        }
        public class Tree<T>
        {
            public Tree<T> Left;
            public Tree<T> Right;
            public T Data;
        }

        public static void DoTree<T>(Tree<T> tree, Action<T> action)
        {
            if (tree == null) return;
            Task taskLeft = Task.Run(() => DoTree(tree.Left, action));
            Task taskRight = Task.Run(() => DoTree(tree.Right, action));
            action(tree.Data);

            Task.WaitAll(taskLeft, taskRight);
        }
    }
}
