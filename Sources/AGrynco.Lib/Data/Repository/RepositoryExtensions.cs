#region Usings
using System;
#endregion

namespace AGrynco.Lib.Data.Repository
{
    public static class RepositoryExtensions
    {
        #region Static Methods (public)
        public static void ExecuteAndCloseConnection<TRepository>(this TRepository repository, Action<TRepository> action)
            where TRepository : IRepository
        {
            try
            {
                action.Invoke(repository);
            }
            finally
            {
                if (!repository.DataProvider.IsInTransaction)
                {
                    repository.DataProvider.CloseConnection();
                }
            }
        }

        public static void ExecuteAndCloseConnection(this IRepository repository, Action action)
        {
            try
            {
                action.Invoke();
            }
            finally
            {
                if (!repository.DataProvider.IsInTransaction)
                {
                    repository.DataProvider.CloseConnection();
                }
            }
        }

        public static TResult ExecuteAndCloseConnection<TResult>(this IRepository repository, Func<TResult> function)
        {
            try
            {
                return function.Invoke();
            }
            finally
            {
                if (!repository.DataProvider.IsInTransaction)
                {
                    repository.DataProvider.CloseConnection();
                }
            }
        }

        public static TResult ExecuteAndCloseConnection<TRepository, TResult>(this TRepository repository, Func<TRepository, TResult> function)
            where TRepository : IRepository
        {
            try
            {
                return function.Invoke(repository);
            }
            finally
            {
                if (!repository.DataProvider.IsInTransaction)
                {
                    repository.DataProvider.CloseConnection();
                }
            }
        }
        #endregion
    }
}