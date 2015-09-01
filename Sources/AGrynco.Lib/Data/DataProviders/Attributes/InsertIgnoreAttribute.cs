#region Usings
using System;
#endregion

namespace AGrynCo.Lib.Data.DataProviders.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class InsertIgnoreAttribute : Attribute
    {
    }
}