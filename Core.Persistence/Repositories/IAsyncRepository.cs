using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Core.Persistence.Dynamic;

namespace Core.Persistence.Repositories
{
    public interface IAsyncRepository<TEntity, TEntityId>:IQuery<TEntity>
        where TEntity : Entity<TEntityId>
    {
        Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,//silinenleri listlesin mi, listelemesin mi
            bool enableTracking = true,//ef nin izleme desteğinin(tracking) enable edilip edilmeyeceği
            CancellationToken cancellationToken = default//iptal etme işlemi            
         );

        Task<Paginate<TEntity?>> GetListAsync(
               Expression<Func<TEntity, bool>> predicate = null,
               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
               int index = 0,
               int size = 10, //sayfalama 
               bool withDeleted = false,
               bool enableTracking = true,
               CancellationToken cancellationToken = default
            );
        
        Task<Paginate<TEntity?>> GetListBydynamicAsync(
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

        Task<bool> AnyAsync( //aradığımız veri var mı yok mu
              Expression<Func<TEntity, bool>> predicate = null,
               bool withDeleted = false,
               bool enableTracking = true,
               CancellationToken cancellationToken = default
            );

        Task<TEntity> AddAsync(TEntity entity);

        Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entitiy);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entitiy);//çoklu

        Task<TEntity> DeleteAsync(TEntity entity, bool permanent=false);//kalıcı mı sileyim soft mu sileyim

        Task<TEntity> DeleteRangeAsync(ICollection<TEntity> entitiy, bool permanent=false);
    }
}
