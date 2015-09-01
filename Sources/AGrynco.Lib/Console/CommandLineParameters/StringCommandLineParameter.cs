namespace AGrynCo.Lib.Console.CommandLineParameters
{
    public class StringCommandLineParameter : BaseCommandLineParameter<string>
    {
        #region Methods (protected)
        protected override string DoParseValueFromString(string value)
        {
            return value;
        }
        #endregion

        #region Constructors
        public StringCommandLineParameter(string name) : base(name)
        {
        }

        public StringCommandLineParameter(string name, string example) : base(name, example)
        {
        }
        #endregion
    }
}