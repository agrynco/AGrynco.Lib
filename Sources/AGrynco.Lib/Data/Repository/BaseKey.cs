#region Usings

#endregion

using System.Diagnostics;

namespace AGrynCo.Lib.Data.Repository
{
    /// <summary>
    /// Base realization of <see cref="IKey"/>
    /// </summary>
    /// <typeparam name="TKey">The simple type (like <see cref="int" /see>, <see cref="string" /see>, ...</typeparam>
    public abstract class BaseKey<TKey> : IKey
    {
        #region Fields (private)
        private readonly string _name;
        #endregion

        #region Constructors
        protected BaseKey(string name)
        {
            this._name = name;
        }
        #endregion

        #region IKey Properties
        public string Name
        {
            [DebuggerStepThrough]
            get { return this._name; }
        }

        object IKey.Value
        {
            [DebuggerStepThrough]
            get { return this.Value; }
            set { this.Value = (TKey) value; }
        }
        #endregion

        #region IKey Methods
        public abstract void Assign(string value);
        #endregion

        #region Properties (public)
        public TKey Value { get; set; }
        #endregion
    }
}