using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IRepository<TEntity, TEntityId>//:IQuery<TEntity>
        where TEntity : Entity<TEntityId>
    {
        TEntity? Get(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,//silinenleri listlesin mi, listelemesin mi
            bool enableTracking = true,//ef nin izleme desteğinin(tracking) enable edilip edilmeyeceği
            CancellationToken cancellationToken = default//iptal etme işlemi            
         );

        IPaginate<TEntity?> GetList(
               Expression<Func<TEntity, bool>> predicate = null,
               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
               int index = 0,
               int size = 10, //sayfalama 
               bool withDeleted = false,
               bool enableTracking = true,
               CancellationToken cancellationToken = default
            );

        IPaginate<TEntity?> GetListBydynamic(
            DynamicQuery dynamic,
               Expression<Func<TEntity, bool>> predicate = null,
               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
               int index = 0,
               int size = 10, //sayfalama 
               bool withDeleted = false,
               bool enableTracking = true,
               CancellationToken cancellationToken = default
            );

        bool Any( //aradığımız veri var mı yok mu
              Expression<Func<TEntity, bool>> predicate = null,
               bool withDeleted = false,
               bool enableTracking = true,
               CancellationToken cancellationToken = default
            );

        TEntity Add(TEntity entity);

        ICollection<TEntity> AddRange(ICollection<TEntity> entitiy);

        TEntity Update(TEntity entity);

        ICollection<TEntity> UpdateRange(ICollection<TEntity> entitiy);//çoklu

        TEntity Delete(TEntity entity, bool permanent = false);//kalıcı mı sileyim soft mu sileyim

        TEntity DeleteRange(ICollection<TEntity> entitiy, bool permanent = false);
    }
}
