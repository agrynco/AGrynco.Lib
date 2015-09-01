#region Usings
using System;
#endregion

namespace AGrynCo.Lib.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute
    {
    }
}