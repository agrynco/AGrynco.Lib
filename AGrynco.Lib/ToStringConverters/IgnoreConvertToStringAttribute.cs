#region Usings
using System;
#endregion

namespace AGrynco.Lib.ToStringConverters
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreConvertToStringAttribute : Attribute
    {
    }
}