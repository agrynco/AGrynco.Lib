#region Usings
#endregion

#region Usings
#endregion

namespace AGrynco.Lib.Data.Repository
{
    public interface IKey
    {
        #region Abstract Methods
        void Assign(string value);
        #endregion

        #region Properties (public)
        string Name { get; }
        object Value { get; set; }
        #endregion
    }
}