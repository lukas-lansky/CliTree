using System.Collections.Generic;

namespace Lansky.CliTree.TreeRepresentation
{
    public class AdHocTree : ITree
    {
        public string RootValue { get; }

        public IEnumerable<ITree> SubTrees { get; }

        public AdHocTree(string rootValue, params ITree[] subTress)
        {
            RootValue = rootValue;
            SubTrees = subTress;
        }

        public AdHocTree(string rootValue, IEnumerable<ITree> subTrees)
        {
            RootValue = rootValue;
            SubTrees = subTrees;
        }
    }
}
