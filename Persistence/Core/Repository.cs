using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs.ReportDTO;
using Application.Interfaces.General;
using Domain.Entities;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Core
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly DbSet<T> _dbSet;
        protected readonly ApiContext Context;

        public Repository(ApiContext context)
        {
            Context = context;
            _dbSet = Context.Set<T>();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> criteria)
        {
            return _dbSet.Where(x => x.Deleted == false).Where(criteria).OrderByDescending(x => x.CreateDate);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> criteria, PaginationDto pagination)
        {
            var lst = _dbSet.Where(x => x.Deleted == false).Where(criteria).OrderByDescending(x => x.CreateDate);
            return lst;
        }

        public void Add(T entity, Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                var exists = _dbSet.Any(predicate);
                if (exists)
                    return;
            }

            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                ? _dbSet.Count(x => x.Deleted == false)
                : _dbSet.Where(x => x.Deleted == false).Count(predicate);
        }


        public T GetById(Guid id)
        {
            var baseEntities = _dbSet.ToList();
            return _dbSet.FirstOrDefault(x => x.Deleted == false && x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            var lst = _dbSet?.AsNoTracking().Where(x => x.Deleted == false).OrderBy(x => x.CreateDate);

            return lst;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(GetById(entity.Id));
        }

        public void Remove(Expression<Func<T, bool>> criteria)
        {
            _dbSet.Where(criteria).BatchUpdate(a => new T
            {
                Deleted = true,
                ModifyDate = DateTime.Now
            });
        }

        public void Update(T entity, Expression<Func<T, bool>> criteria = null)
        {
            var originalEntity = criteria == null ? GetById(entity.Id) : Find(criteria).FirstOrDefault();
            if (originalEntity != null)
                _dbSet.Update(PrepareEntityForUpdate(originalEntity, entity));
            else
                throw new Exception("The object is not found");
        }

        public IEnumerable<T> GetAll(PaginationDto pagination)
        {
            var lst = _dbSet?.AsNoTracking().Where(x => x.Deleted == false).OrderByDescending(x => x.CreateDate);
            return lst;
        }

        public T GetLikeId(string id)
        {
            return _dbSet.Where(x => x.Deleted == false)
                .FirstOrDefault(x => x.Id.ToString().Contains(id + "-"));
        }


        private T PrepareEntityForUpdate(T original, T manipulated)
        {
            var originalProperties = Context.Entry(original).Properties.ToList();
            var manipulatedProperties = Context.Entry(manipulated).Properties.ToList();

            foreach (var manipulatedProperty in manipulatedProperties)
            foreach (var originalProperty in originalProperties)
            {
                if (originalProperty.Metadata.Name != manipulatedProperty.Metadata.Name
                    || originalProperty.Metadata.Name == "CreateDate")
                    continue;

                var manipulatedPropertyCurrentValue = manipulatedProperty.CurrentValue;

                switch (manipulatedPropertyCurrentValue)
                {
                    case null:
                    case Guid guid when guid == Guid.Empty:
                    case DateTime _ when manipulatedPropertyCurrentValue.ToString() == new DateTime().ToString():
                        continue;
                }

                if (originalProperty.CurrentValue == null)
                {
                    originalProperty.CurrentValue = manipulatedPropertyCurrentValue;
                    continue;
                }


                if (originalProperty.CurrentValue != null &&
                    originalProperty.CurrentValue.Equals(manipulatedPropertyCurrentValue) == false)
                    originalProperty.CurrentValue = manipulatedPropertyCurrentValue;
            }

            return original;
        }


        public IQueryable<T> PagedResult<T, TResult>(IQueryable<T> query, DataTransferObject<T> dataTransferObject,
            Expression<Func<T, TResult>> orderByProperty, bool isAscendingOrder)
        {
            if (dataTransferObject.Pagination.PageSize <= 0) dataTransferObject.Pagination.PageSize = 20;

            //مجموع ردیف‌های به دست آمده
            dataTransferObject.TotalRow = query.Count();

            // اگر شماره صفحه کوچکتر از 0 بود صفحه اول نشان داده شود
            if (dataTransferObject.TotalRow <= dataTransferObject.Pagination.PageSize ||
                dataTransferObject.Pagination.PageNum <= 0) dataTransferObject.Pagination.PageNum = 1;

            // محاسبه ردیف هایی که نسبت به سایز صفحه باید از آنها گذشت
            var excludedRows = (dataTransferObject.Pagination.PageNum - 1) * dataTransferObject.Pagination.PageSize;

            //query = isAscendingOrder ? query.OrderBy(orderByProperty) : query.OrderByDescending(orderByProperty);

            // ردشدن از ردیف‌های اضافی و  دریافت ردیف‌های مورد نظر برای صفحه مربوطه
            return query.Skip(excludedRows).Take(dataTransferObject.Pagination.PageSize);
        }
    }
}