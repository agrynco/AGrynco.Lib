namespace AGrynco.Lib.Console.CommandLineParameters
{
    public interface ICommandLineParameter
    {
        #region Abstract Methods
        string BuildExample();
        void ParseValueFromString(string value);
        #endregion

        #region Properties (public)
        object Example { get; }

        string Name { get; set; }
        object Value { get; }

        bool Required { get; set; }
        #endregion
    }

    public interface ICommandLineParameter<TValue> : ICommandLineParameter
    {
        #region Properties (public)
        new string Example { get; }

        new TValue Value { get; }
        #endregion
    }
}