using System;

namespace Lansky.CliTree.ConsoleWrapper
{
    class InMemoryConsole : IConsole
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
