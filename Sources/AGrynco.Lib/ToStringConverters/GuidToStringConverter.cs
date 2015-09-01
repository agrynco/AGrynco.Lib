#region Usings
using System;
#endregion

namespace AGrynCo.Lib.ToStringConverters
{
    public class GuidToStringConverter : BaseToStringConverter<Guid>
    {
        #region Methods (public)
        public override string Convert(Guid value)
        {
            return string.Format("'{0}'", value);
        }
        #endregion
    }
}