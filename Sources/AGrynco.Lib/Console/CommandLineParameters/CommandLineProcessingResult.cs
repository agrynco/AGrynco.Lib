#region Usings
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace AGrynCo.Lib.Console.CommandLineParameters
{
    public class CommandLineProcessingResult
    {
        #region Fields (private)
        private readonly IEnumerable<ICommandLineParameter> _absentCommandLineParameters;
        private readonly IEnumerable<ICommandLineParameter> _completeCommadLineParameters;

        private readonly bool _isValid;
        private readonly IEnumerable<ICommandLineParameter> _uncompleteCommadLineParameters;
        #endregion

        #region Constructors
        public CommandLineProcessingResult(IEnumerable<ICommandLineParameter> absentCommandLineParameters,
                                           IEnumerable<ICommandLineParameter> uncompleteCommadLineParameters,
                                           IEnumerable<ICommandLineParameter> completeCommadLineParameters)
        {
            _absentCommandLineParameters = absentCommandLineParameters;
            _uncompleteCommadLineParameters = uncompleteCommadLineParameters;
            _completeCommadLineParameters = completeCommadLineParameters;

            _isValid = !_absentCommandLineParameters.Any() && !_uncompleteCommadLineParameters.Any();
        }
        #endregion

        #region Methods (public)
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(ToStringCommandLineParameters("Absent parameters are: ", _absentCommandLineParameters));
            stringBuilder.AppendLine(ToStringCommandLineParameters("Complete parameters are: ", _completeCommadLineParameters));
            stringBuilder.AppendLine(ToStringCommandLineParameters("Uncomplete parameters are: ", _uncompleteCommadLineParameters));

            return stringBuilder.ToString();
        }
        #endregion

        #region Methods (private)
        private string ToStringCommandLineParameters(string prefix, IEnumerable<ICommandLineParameter> commandLineParameters)
        {
            return string.Format("{0} {1}", prefix, string.Join("; ", commandLineParameters));
        }
        #endregion

        #region Properties (public)
        public IEnumerable<ICommandLineParameter> AbsentCommandLineParameters
        {
            get { return _absentCommandLineParameters; }
        }

        public IEnumerable<ICommandLineParameter> CompleteCommadLineParameters
        {
            get { return _completeCommadLineParameters; }
        }

        public bool IsValid
        {
            get { return _isValid; }
        }

        public IEnumerable<ICommandLineParameter> UncompleteCommadLineParameters
        {
            get { return _uncompleteCommadLineParameters; }
        }
        #endregion
    }
}