using Lansky.CliTree.ConsoleWrapper;
using Lansky.CliTree.TreeRepresentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.AreEqual("└─ child", console.GetOutputLines()[1]);
        }

        [TestMethod]
        public void ManyChildrenOfRootNode()
        {
            var console = new StringBuilderConsole();
            CliTree.Print(
                new AdHocTree("root",
                    new AdHocTree("child 1"),
                    new AdHocTree("child 2"),
                    new AdHocTree("child 3")),
                console);

            Assert.AreEqual(4, console.GetOutputLines().Count);
            Assert.AreEqual("root", console.GetOutputLines()[0]);
            Assert.AreEqual("├─ child 1", console.GetOutputLines()[1]);
            Assert.AreEqual("├─ child 2", console.GetOutputLines()[2]);
            Assert.AreEqual("└─ child 3", console.GetOutputLines()[3]);
        }

        [TestMethod]
        public void DeepChildrenOfRootNode()
        {
            var console = new StringBuilderConsole();
            CliTree.Print(
                new AdHocTree("root",
                    new AdHocTree("child",
                        new AdHocTree("grandchild",
                            new AdHocTree("grandgrandchild")))), console);

            Assert.AreEqual(4, console.GetOutputLines().Count);
            Assert.AreEqual("root", console.GetOutputLines()[0]);
            Assert.AreEqual("└─ child", console.GetOutputLines()[1]);
            Assert.AreEqual("  └─ grandchild", console.GetOutputLines()[2]);
            Assert.AreEqual("    └─ grandgrandchild", console.GetOutputLines()[3]);
        }

        [TestMethod]
        public void DeepChildrenOfRootNodeWithOneMoreChildlessChild()
        {
            var console = new StringBuilderConsole();
            CliTree.Print(
                new AdHocTree("root",
                    new AdHocTree("child 1",
                        new AdHocTree("grandchild",
                            new AdHocTree("grandgrandchild"))),
                    new AdHocTree("child 2")), console);

            Assert.AreEqual(5, console.GetOutputLines().Count);
            Assert.AreEqual("root", console.GetOutputLines()[0]);
            Assert.AreEqual("├─ child 1", console.GetOutputLines()[1]);
            Assert.AreEqual("│ └─ grandchild", console.GetOutputLines()[2]);
            Assert.AreEqual("│   └─ grandgrandchild", console.GetOutputLines()[3]);
            Assert.AreEqual("└─ child 2", console.GetOutputLines()[4]);
        }

        [TestMethod]
        public void JustAnotherDeepChildrenSituation()
        {
            var console = new StringBuilderConsole();
            CliTree.Print(
                new AdHocTree("root",
                    new AdHocTree("child 1",
                        new AdHocTree("grandchild 1",
                            new AdHocTree("grandgrandchild 1"),
                            new AdHocTree("grandgrandchild 2")),
                        new AdHocTree("grandchild 2")),
                    new AdHocTree("child 2")), console);

            Assert.AreEqual(7, console.GetOutputLines().Count);
            Assert.AreEqual("root", console.GetOutputLines()[0]);
            Assert.AreEqual("├─ child 1", console.GetOutputLines()[1]);
            Assert.AreEqual("│ ├─ grandchild 1", console.GetOutputLines()[2]);
            Assert.AreEqual("│ │ ├─ grandgrandchild 1", console.GetOutputLines()[3]);
            Assert.AreEqual("│ │ └─ grandgrandchild 2", console.GetOutputLines()[4]);
            Assert.AreEqual("│ └─ grandchild 2", console.GetOutputLines()[5]);
            Assert.AreEqual("└─ child 2", console.GetOutputLines()[6]);
        }

        [TestMethod]
        public void JustAnotherDeepChildrenSituationWithLinesTurnedOff()
        {
            var console = new StringBuilderConsole();
            CliTree.Print(
                new AdHocTree("root",
                    new AdHocTree("child 1",
                        new AdHocTree("grandchild 1",
                            new AdHocTree("grandgrandchild 1"),
                            new AdHocTree("grandgrandchild 2")),
                        new AdHocTree("grandchild 2")),
                    new AdHocTree("child 2")), console, new DisplayConfiguration { ShowLines = false });

            Assert.AreEqual(7, console.GetOutputLines().Count);
            Assert.AreEqual("root", console.GetOutputLines()[0]);
            Assert.AreEqual("  child 1", console.GetOutputLines()[1]);
            Assert.AreEqual("    grandchild 1", console.GetOutputLines()[2]);
            Assert.AreEqual("      grandgrandchild 1", console.GetOutputLines()[3]);
            Assert.AreEqual("      grandgrandchild 2", console.GetOutputLines()[4]);
            Assert.AreEqual("    grandchild 2", console.GetOutputLines()[5]);
            Assert.AreEqual("  child 2", console.GetOutputLines()[6]);
        }
    }
}
