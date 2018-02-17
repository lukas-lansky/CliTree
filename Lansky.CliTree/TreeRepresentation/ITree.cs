using System.Collections.Generic;

namespace Lansky.CliTree.TreeRepresentation
{
    public interface ITree
    {
        string RootValue { get; }

        IEnumerable<ITree> SubTrees { get; }
    }
}
