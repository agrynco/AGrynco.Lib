namespace AGrynCo.Lib.Console.CommandLineParameters
{
    public class IntCommandLineParameter : BaseCommandLineParameter<int>
    {
        #region Constructors
        public IntCommandLineParameter(string name) : base(name)
        {
        }

        public IntCommandLineParameter(string name, string example) : base(name, example)
        {
        }
        #endregion

        #region Methods (protected)
        protected override int DoParseValueFromString(string value)
        {
            return int.Parse(value);
        }
        #endregion
    }
}