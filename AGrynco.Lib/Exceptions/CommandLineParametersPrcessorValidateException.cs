namespace AGrynco.Lib.Exceptions
{
    public class CommandLineParametersPrcessorValidateException : CommandLineParameterException
    {
        #region Constructors
        public CommandLineParametersPrcessorValidateException(ParseCommandLineParameterException ex)
            : base(ex.Message, ex)
        {
        }
        #endregion
    }
}