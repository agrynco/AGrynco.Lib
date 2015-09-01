#region Usings
using System;
#endregion

namespace AGrynCo.Lib.Exceptions
{
    public class ParseCommandLineParameterException : CommandLineParameterException
    {
        #region Constructors
        public ParseCommandLineParameterException(string nameOfCommandLineParameter, Type typeOfValue, string stringValueToParse, Exception ex)
            : base(string.Format("Can not parse value from string = '{0}' to type {1} for command line parameter with name = '{2}'", stringValueToParse, typeOfValue, stringValueToParse), ex)
        {
        }

        public ParseCommandLineParameterException(string nameOfCommandLineParameter, Type typeOfValue, string stringValueToParse)
            : this(nameOfCommandLineParameter, typeOfValue, nameOfCommandLineParameter, null)
        {
        }
        #endregion
    }
}