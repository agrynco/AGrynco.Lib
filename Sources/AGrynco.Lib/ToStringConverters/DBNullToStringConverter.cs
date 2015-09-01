#region Usings
using System;
#endregion

namespace AGrynCo.Lib.ToStringConverters
{
    public class DBNullToStringConverter : BaseToStringConverter<DBNull>
    {
        #region Methods (public)
        public override string Convert(DBNull value)
        {
            return string.Empty;
        }
        #endregion
    }
}