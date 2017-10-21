#region Usings
using AGrynCo.Lib.Console.CommandLineParameters;
#endregion

namespace CommandLineParameters.Example.Console
{
    class Program
    {
        private static readonly ICommandLineParameter _INPUT = new StringCommandLineParameter("input", @"C:\Temp\input.csv");
        private static readonly ICommandLineParameter _OUTPUT = new StringCommandLineParameter("output", @"C:\Temp\output.csv");

        private static readonly ICommandLineParameter[] _COMMAND_LINE_PARAMETERS = { _INPUT, _OUTPUT };

        private static readonly ICommandLineParameter[][] _SET_OF_SEQUENCES_OF_COMMAND_LINE_PARAMETERS =
            {
                _COMMAND_LINE_PARAMETERS,
                _COMMAND_LINE_PARAMETERS
            };

        static void Main(string[] args)
        {
            CommandLineParametersPrcessor.PrintCommandLineParamsInfo(_SET_OF_SEQUENCES_OF_COMMAND_LINE_PARAMETERS);
            System.Console.ReadLine();
        }
    }
}