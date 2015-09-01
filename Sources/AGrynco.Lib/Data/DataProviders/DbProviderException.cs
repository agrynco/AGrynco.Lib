#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynCo.Lib.Data.DataProviders
{
    public class DbProviderException : Exception
    {
        #region Constructors
        public DbProviderException()
        {
        }

        public DbProviderException(string message)
            : base(message)
        {
        }

        public DbProviderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DbProviderException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}