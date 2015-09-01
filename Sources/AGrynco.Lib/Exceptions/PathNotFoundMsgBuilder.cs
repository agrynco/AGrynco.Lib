#region Usings
#endregion

#region Usings
#endregion

namespace AGrynCo.Lib.Exceptions
{
    public class PathNotFoundMsgBuilder
    {
        #region Constructors
        private PathNotFoundMsgBuilder()
        {
        }
        #endregion

        #region Static Methods (public)
        /// <summary>
        /// Build string message 
        /// </summary>
        /// <param name="path">Path to data source</param>
        /// <returns>Message</returns>
        public static string Build(string path)
        {
            return string.Format("Path '{0}' not found", path);
        }
        #endregion
    }
}