#region Usings
#endregion

#region Usings
#endregion

using System;

namespace AGrynco.Lib.Data.Repository
{
    public class KeyInt : BaseKey<Int64?>
    {
        #region Constants
        public const string IDENTIFIER_KEY_NAME = "Id";
        #endregion

        #region Constructors
        public KeyInt(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Creates new instance with default name <see cref="IDENTIFIER_KEY_NAME"/>
        /// </summary>
        public KeyInt()
            : base(IDENTIFIER_KEY_NAME)
        {
        }
        #endregion

        #region Methods (public)
        public override void Assign(string value)
        {
            this.Value = Int64.Parse(value);
        }
        #endregion
    }
}