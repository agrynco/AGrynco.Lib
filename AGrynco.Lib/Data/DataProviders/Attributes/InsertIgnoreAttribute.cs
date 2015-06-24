#region Usings
using System;
#endregion

namespace AGrynco.Lib.Data.DataProviders.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class InsertIgnoreAttribute : Attribute
    {
    }
}