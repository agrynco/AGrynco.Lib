#region Usings
using System;
using System.Collections.Generic;

using AGrynco.Lib.Data.DataProviders;
using AGrynco.Lib.Data.Repository.Exceptions;
#endregion

namespace AGrynco.Lib.Data.Repository
{
    public abstract class BaseRepository<TEntity, TEntityIdentifier> : IReadOnlyRepository<TEntity, TEntityIdentifier>
        where TEntity : BaseEntity<TEntityIdentifier>, new() where TEntityIdentifier : BaseMultiKey, IMultiKey, new()
    {
        #region Fields (private)
        private readonly IDataProvider _dataProvider;
        #endregion

        #region Constructors
        public BaseRepository(IDataProvider dataProvider)
        {
            if (dataProvider == null)
            {
                throw new ArgumentNullException("dataProvider");
            }

            _dataProvider = dataProvider;
        }
        #endregion

        #region Properties (protected)
        protected IDataProvider DataProvider
        {
            get
            {
                return _dataProvider;
            }
        }
        #endregion

        #region IReadOnlyRepository<TEntity,TEntityIdentifier> Properties
        IDataProvider IRepository.DataProvider
        {
            get
            {
                return DataProvider;
            }
        }
        #endregion

        #region Abstract Methods
        protected abstract IDbDataReader DoGetEntityReader(TEntityIdentifier identifier);
        #endregion

        #region IReadOnlyRepository<TEntity,TEntityIdentifier> Methods
        public void Dispose()
        {
            DataProvider.Dispose();
        }

        public virtual TEntity Read(TEntityIdentifier identifier)
        {
            if (identifier.AllKeysHasValue)
            {
                return ReadSingle(
                                  () =>
                                      {
                                          IDbDataReader dbDataReader = DoGetEntityReader(identifier);
                                          return new GettingReaderResult(dbDataReader, string.Format("getter by identifier ({0})", identifier));
                                      });
            }

            throw new NotAllKeysHaveValueException();
        }
        #endregion

        #region Methods (protected)
        protected TEntity BuildAndPopulateEntity(IDbDataReader reader)
        {
            TEntity entity = new TEntity();

            Populate(entity, reader);

            return entity;
        }

        protected TEntity[] Populate(IDbDataReader reader)
        {
            List<TEntity> result = new List<TEntity>();

            try
            {
                while (reader.Read())
                {
                    result.Add(BuildAndPopulateEntity(reader));
                }

                return result.ToArray();
            }
            finally
            {
                reader.Close();
            }
        }

        protected virtual void Populate(TEntity entity, IDbDataReader reader)
        {
            reader.Populate(entity);
        }

        private TEntity ReadSingle(Func<GettingReaderResult> readerGetter)
        {
            using (GettingReaderResult gettingReaderResult = readerGetter.Invoke())
            {
                if (!gettingReaderResult.DataReader.Read())
                {
                    string message = string.Format("Can not get entity \"'{0}'\" with ({1})", typeof(TEntity), gettingReaderResult.Description);
                    //Logger.Error(this, message);
                    throw new ThereIsNoDataException(message);
                }

                TEntity result = BuildAndPopulateEntity(gettingReaderResult.DataReader);

                if (gettingReaderResult.DataReader.Read())
                {
                    throw new ToManyRecordsException(string.Format("The readerGetter \"{0}\" must return only one record!", gettingReaderResult.Description));
                }

                return result;
            }
        }
        #endregion
    }
}