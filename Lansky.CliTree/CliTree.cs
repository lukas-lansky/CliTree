using Lansky.CliTree.ConsoleWrapper;
using Lansky.CliTree.TreeRepresentation;
using System.Collections.Generic;

namespace Lansky.CliTree
{
    public static class CliTree
    {
        public static void Print(ITree tree)
        {
            Print(tree, new InMemoryConsole());
        }

        public static void Print(ITree tree, IConsole console, DisplayConfiguration config = null)
        {
            config = config ?? new DisplayConfiguration();

            var stack = new Stack<(ITree tree, int depth)>();
            stack.Push((tree, 0));

            while (stack.Count > 0)
            {
                (var t, var d) = stack.Pop();

                console.WriteLine(new string(' ', d * 2) + t.RootValue);

                foreach (var subtree in t.SubTrees)
                {
                    stack.Push((subtree, d + 1));
                }
            }
        }
    }
}
