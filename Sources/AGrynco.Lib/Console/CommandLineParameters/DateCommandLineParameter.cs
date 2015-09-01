#region Usings
using System;
#endregion

namespace AGrynCo.Lib.Console.CommandLineParameters
{
    public class DateCommandLineParameter : BaseCommandLineParameter<DateTime>
    {
        #region Fields (private)
        private readonly IFormatProvider _formatProvider;
        #endregion

        #region Constructors
        public DateCommandLineParameter(string name) : base(name)
        {
            _formatProvider = null;
        }

        public DateCommandLineParameter(string name, string example)
            : this(name, example, null)
        {
        }

        public DateCommandLineParameter(string name, string example, IFormatProvider formatProvider)
            : base(name, example)
        {
            _formatProvider = formatProvider;
        }
        #endregion

        #region Methods (protected)
        protected override DateTime DoParseValueFromString(string value)
        {
            return _formatProvider == null ? DateTime.Parse(value) : DateTime.Parse(value, _formatProvider);
        }
        #endregion
    }
}