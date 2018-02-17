using Lansky.CliTree.ConsoleWrapper;
using Lansky.CliTree.TreeRepresentation;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            var stack = new Stack<(ITree tree, int depth, List<bool> last)>();
            stack.Push((tree, 0, new List<bool>()));

            while (stack.Count > 0)
            {
                (var t, var currentDepth, var last) = stack.Pop();

                var line = config.ShowLines
                    ? GetLineWithLines(currentDepth, last, t.RootValue)
                    : GetLineWithoutLines(currentDepth, t.RootValue);
                console.WriteLine(line.ToString());

                var st = t.SubTrees.ToList();
                for (var i = st.Count - 1; i >= 0; i--)
                {
                    var newLast = new List<bool>(last); // TODO, this is quite wasteful
                    newLast.Add(i == st.Count - 1);
                    stack.Push((st[i], currentDepth + 1, newLast));
                }
            }
        }
        
        private static string GetLineWithLines(int currentDepth, List<bool> last, string caption)
        {
            var line = new StringBuilder();

            for (var i = 0; i < currentDepth; i++)
            {
                if (i != currentDepth - 1)
                {
                    if (!last[i])
                    {
                        line.Append('│');
                    }
                    else
                    {
                        line.Append(' ');
                    }
                }
                else
                {
                    if (!last[i])
                    {
                        line.Append('├');
                    }
                    else
                    {
                        line.Append('└');
                    }
                }

                if (i == currentDepth - 1)
                {
                    line.Append("─");
                }

                line.Append(' ');
            }
            line.Append(caption);

            return line.ToString();
        }

        private static string GetLineWithoutLines(int currentDepth, string caption)
        {
            return new string(' ', currentDepth * 2) + caption;
        }
    }
}
