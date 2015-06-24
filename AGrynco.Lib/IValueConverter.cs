#region Usings
using System;
#endregion

namespace AGrynco.Lib
{
    /// <summary>
    /// Non generic realisation doesn't contains Convert method because we use this interface as 'container'
    /// to hold generic implementations in factory's dictionary. For calling Convert method you should cast 
    /// it to <see cref="IValueConverter{T}"/>.
    /// </summary>
    public interface IValueConverter
    {
        #region Properties (public)
        Type ConversionResultType { get; }
        #endregion
    }

    public interface IValueConverter<out T> : IValueConverter
    {
        #region Abstract Methods
        T Convert(object value);
        #endregion
    }
}