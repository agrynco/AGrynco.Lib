#region Usings
using AGrynCo.Lib.Console.CommandLineParameters;

using NUnit.Framework;
#endregion

namespace AGrynco.Lib.Tests
{
    [TestFixture]
    public class CommandLineParametersTests
    {
        private static readonly ICommandLineParameter _INPUT = new StringCommandLineParameter("input", @"C:\Temp\input.csv");
        private static readonly ICommandLineParameter _OUTPUT = new StringCommandLineParameter("output", @"C:\Temp\output.csv");

        private static readonly ICommandLineParameter[] _COMMAND_LINE_PARAMETERS = { _INPUT, _OUTPUT };

        private static readonly ICommandLineParameter[][] _SET_OF_SEQUENCES_OF_COMMAND_LINE_PARAMETERS =
            {
                _COMMAND_LINE_PARAMETERS,
                _COMMAND_LINE_PARAMETERS
            };

        [Test]
        public void PrintCommandLineParamsInfo()
        {
            CommandLineParametersPrcessor.PrintCommandLineParamsInfo(_SET_OF_SEQUENCES_OF_COMMAND_LINE_PARAMETERS);
        }
    }
}