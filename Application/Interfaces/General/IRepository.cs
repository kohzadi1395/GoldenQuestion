using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs.ReportDTO;
using Domain.Entities;

namespace Application.Interfaces.General
{
    public interface IRepository<T> where T : BaseEntity
    {
        int Count(Expression<Func<T, bool>> predicate = null);

        T GetById(Guid id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(PaginationDto pagination);

        IEnumerable<T> Find(Expression<Func<T, bool>> criteria);

        IEnumerable<T> Find(Expression<Func<T, bool>> criteria, PaginationDto pagination);

        void Add(T entity, Expression<Func<T, bool>> predicate = null);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void Remove(Expression<Func<T, bool>> criteria);

        void Update(T entity, Expression<Func<T, bool>> criteria = null);
    }
}