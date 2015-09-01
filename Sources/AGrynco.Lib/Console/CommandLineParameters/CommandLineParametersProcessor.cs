#region Usings
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AGrynCo.Lib.Exceptions;
#endregion

namespace AGrynCo.Lib.Console.CommandLineParameters
{
    public static class CommandLineParametersPrcessor
    {
        #region Static Methods (public)
        public static void PrintCommandLineParamsInfo(ICommandLineParameter[][] setOfSequencesOfCommandLineParameters)
        {
            FileInfo exeFileInfo = new FileInfo(Assembly.GetEntryAssembly().Location);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (ICommandLineParameter<string>[] sequenceOfCoCommandLineParameters in setOfSequencesOfCommandLineParameters)
            {
                stringBuilder.Append(exeFileInfo.Name).Append(" ");
                foreach (ICommandLineParameter<string> commandLineParameter in sequenceOfCoCommandLineParameters)
                {
                    stringBuilder.Append(commandLineParameter.BuildExample()).Append("");
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append(" ");
                    }
                }
                stringBuilder.AppendLine();
            }

            ConsoleExtensions.WriteInfo(stringBuilder.ToString());
        }

        public static CommandLineProcessingResult Process(IEnumerable<string> args, IEnumerable<ICommandLineParameter> commandLineParameters)
        {
            List<ICommandLineParameter> completeCommandLineParameters = new List<ICommandLineParameter>();
            List<ICommandLineParameter> presentCommandLineParameters = new List<ICommandLineParameter>();
            List<ICommandLineParameter> uncompleteCommadLineParameters = new List<ICommandLineParameter>();

            foreach (string arg in args)
            {
                int indexOfFirstEquall = arg.IndexOf("=");

                if (indexOfFirstEquall == -1)
                {
                    throw new NotSupportedException();
                }

                string paramName = arg.Substring(0, indexOfFirstEquall);
                string paramValue = arg.Substring(indexOfFirstEquall + 1);

                ICommandLineParameter commandLineParameter = commandLineParameters.SingleOrDefault(x => x.Name == paramName);
                if (commandLineParameter != null)
                {
                    presentCommandLineParameters.Add(commandLineParameter);

                    try
                    {
                        commandLineParameter.ParseValueFromString(paramValue);
                        completeCommandLineParameters.Add(commandLineParameter);
                    }
                    catch (ParseCommandLineParameterException)
                    {
                        if (commandLineParameter.Required)
                        {
                            uncompleteCommadLineParameters.Add(commandLineParameter);
                        }
                    }
                }
            }

            IEnumerable<ICommandLineParameter> absentCommandLineParameters = commandLineParameters.Except(presentCommandLineParameters).Where(parameter => parameter.Required);

            return new CommandLineProcessingResult(absentCommandLineParameters, uncompleteCommadLineParameters, completeCommandLineParameters);
        }
        #endregion
    }
}