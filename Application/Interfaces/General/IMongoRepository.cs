using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces.General
{
    public interface IMongoRepository<T>
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> criteria);
        void Add(T entity, Expression<Func<T, bool>> predicate = null);
        void AddRange(IEnumerable<T> entities);
        Task<long> Count(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        void Remove(T entity);
        void RemoveRange(Expression<Func<T, bool>> predicate);
        void Replace(T entity, Expression<Func<T, bool>> predicate);
    }
}