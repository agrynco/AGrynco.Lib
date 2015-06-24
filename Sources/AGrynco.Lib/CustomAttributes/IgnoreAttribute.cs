#region Usings
using System;
#endregion

namespace AGrynco.Lib.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute
    {
    }
}