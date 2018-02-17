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
                (var t, var d, var last) = stack.Pop();

                var line = new StringBuilder();
                for (var i = 0; i < d; i++)
                {
                    if (i != d - 1)
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

                    if (i == d - 1)
                    {
                        line.Append("─");
                    }

                    line.Append(' ');
                }
                line.Append(t.RootValue);
                console.WriteLine(line.ToString());

                var st = t.SubTrees.ToList();
                for (var i = st.Count - 1; i >= 0; i--)
                {
                    var newLast = new List<bool>(last); // TODO, this is quite wasteful
                    newLast.Add(i == st.Count - 1);
                    stack.Push((st[i], d + 1, newLast));
                }
            }
        }
    }
}
