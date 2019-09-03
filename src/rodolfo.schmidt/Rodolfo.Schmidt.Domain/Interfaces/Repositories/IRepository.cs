using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rodolfo.Schmidt.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> FetchExpression(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> FetchExpression(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> FetchExpression(Expression<Func<TEntity, bool>> where, int start, int limit, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> FetchExpression(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, int>> orderby,
            params Expression<Func<TEntity, object>>[] includes);
        void Save(TEntity entity);
        void SaveMany(IEnumerable<TEntity> entity);
        void Delete(TEntity entity);
        void DeleteMany(IEnumerable<TEntity> entity);

    }
}
