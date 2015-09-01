#region Usings
using System;
#endregion

namespace AGrynCo.Lib.ToStringConverters
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreConvertToStringAttribute : Attribute
    {
    }
}