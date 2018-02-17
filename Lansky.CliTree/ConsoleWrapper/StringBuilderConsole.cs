using System.Collections.Generic;
using System.Text;

namespace Lansky.CliTree.ConsoleWrapper
{
    public class StringBuilderConsole : IConsole
    {
        private List<string> _outputSoFar = new List<string>();

        public void WriteLine(string line)
        {
            _outputSoFar.Add(line);
        }

        public string GetOutput()
        {
            var sb = new StringBuilder();

            foreach (var line in _outputSoFar)
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public IList<string> GetOutputLines()
            => new List<string>(_outputSoFar);
    }
}
