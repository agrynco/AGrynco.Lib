#region Usings
using System.Collections;
using System.Text;
#endregion

namespace AGrynco.Lib.ToStringConverters
{
    public class EnumerableToStringConverter : BaseToStringConverter<IEnumerable>
    {
        #region Methods (public)
        public override string Convert(IEnumerable value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (object o in value)
            {
                if (stringBuilder.Length != 0)
                {
                    stringBuilder.Append(", ");
                }
                stringBuilder.Append(ToStringConverter.Instance.Convert(o));
            }
            return stringBuilder.Insert(0, '(').Append(')').ToString();
        }
        #endregion
    }
}