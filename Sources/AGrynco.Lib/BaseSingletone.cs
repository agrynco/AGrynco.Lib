#region Usings
using System;
using System.Threading;
#endregion

namespace AGrynco.Lib
{
    public class BaseSingletone<T>
        where T : class
    {
        #region Static Fields (private)
        private static T _instance;
        #endregion

        #region Constructors
        protected BaseSingletone()
        {
        }
        #endregion

        #region Static Properties (public)
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(T))
                    {
                        if (_instance == null)
                        {
                            T singletone = (T)Activator.CreateInstance(typeof(T), true);
                            Thread.MemoryBarrier();
                            _instance = singletone;
                        }
                    }
                }

                return _instance;
            }
        }
        #endregion
    }
}