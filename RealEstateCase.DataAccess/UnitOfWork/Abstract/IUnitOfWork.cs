using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using System.Data;

namespace RealEstateCase.DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        void OpenTransaction();
        void OpenTransaction(IsolationLevel isolationLevel);
        void Commit();
        void Rollback();
        BaseResponseModel<int> SaveChanges();
        Task<BaseResponseModel<int>> SaveChangesAsync(CancellationToken cancellationToken);
        TRepo Repository<TRepo>() where TRepo : IBaseRepository;
    }
}
