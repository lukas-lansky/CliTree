using Lansky.CliTree.ConsoleWrapper;
using Lansky.CliTree.TreeRepresentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lansky.CliTree.Test
{
    [TestClass]
    public class CliTreeTest
    {
        [TestMethod]
        public void SingleNodeProducesSingleLine()
        {
            var console = new StringBuilderConsole();
            CliTree.Print(new AdHocTree("root"), console);

            Assert.AreEqual(1, console.GetOutputLines().Count);
            Assert.AreEqual("root", console.GetOutputLines()[0]);
        }

        [TestMethod]
        public void NodeWithChildProducesTwoLinesConnected()
        {
            var console = new StringBuilderConsole();
            CliTree.Print(new AdHocTree("root", new AdHocTree("child")), console);

            Assert.AreEqual(2, console.GetOutputLines().Count);
            Assert.AreEqual("root", console.GetOutputLines()[0]);
            Assert.AreEqual("  child", console.GetOutputLines()[1]);
        }
    }
}
