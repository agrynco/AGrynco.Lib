namespace AGrynco.Lib.Data.DataProviders
{
    public class SqlDbScript : IDbScript
    {
        #region Fields (private)
        private readonly string _scriptText;
        #endregion

        #region Constructors
        public SqlDbScript(string scriptText)
        {
            _scriptText = scriptText;
        }
        #endregion

        #region IDbScript Methods
        public override string ToString()
        {
            return _scriptText;
        }
        #endregion
    }
}