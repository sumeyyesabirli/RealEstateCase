using Microsoft.EntityFrameworkCore;
using RealEstateCase.Core.Entities;
using RealEstateCase.DataAccess.Repositories.Abstract;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    public class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(TContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public virtual TEntity Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public virtual IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public virtual TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
