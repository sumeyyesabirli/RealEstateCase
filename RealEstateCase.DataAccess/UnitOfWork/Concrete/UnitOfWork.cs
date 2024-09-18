using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using System.Data;
using System.Reflection;

namespace RealEstateCase.DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork<TContext> : IUnitOfWork, IDisposable where TContext : DbContext
    {
        private readonly TContext _dbContext;
        private IDbContextTransaction _transaction;
        private bool _disposed;
        public UnitOfWork(TContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            try
            {
                _dbContext.SaveChanges();
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                if (this._transaction != null)
                {
                    this._transaction.Dispose();
                    this._transaction = null;
                }

                _dbContext.Dispose();
            }
            _disposed = true;
        }

        public void OpenTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void OpenTransaction(IsolationLevel isolationLevel)
        {
            _transaction = _transaction ?? _dbContext.Database.BeginTransaction();
        }

        public Dictionary<Type, object> Repositories = new();
        public TRepo Repository<TRepo>() where TRepo : IBaseRepository
        {
            var repositoryClass = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes()).FirstOrDefault(x => typeof(TRepo).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            if (repositoryClass == null)
            {
                throw new NotImplementedException("Requested repository not found!");
            }

            var entityType = ((Type[])((TypeInfo)repositoryClass).ImplementedInterfaces)[0]
                .GenericTypeArguments.FirstOrDefault();
            if (entityType == null)
            {
                throw new NotImplementedException("Requested repository not found!");
            }

            if (Repositories.Keys.Contains(entityType))
            {
                return (TRepo)Repositories[entityType];
            }

            TRepo repo = default(TRepo);
            try
            {
                repo = (TRepo)Activator.CreateInstance(
                    repositoryClass, _dbContext);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Repositories.Add(entityType, repo);
            return repo;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
        public BaseResponseModel<int> SaveChanges()
        {
            try
            {
                int affectedRowNumber = _dbContext.SaveChanges();

                return ResponseManager.Ok(affectedRowNumber);
            }
            catch (Exception ex)
            {
                _transaction?.Rollback();

                return ResponseManager.BadRequest<int>(ex.Message);
            }
        }

        public async Task<BaseResponseModel<int>> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                int affectedRowNumber = await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseManager.Ok(affectedRowNumber);
            }
            catch (Exception ex)
            {
                _transaction?.Rollback();

                return ResponseManager.BadRequest<int>("SqlException",new List<string> { ex.Message });
            }
        }
    }
}
