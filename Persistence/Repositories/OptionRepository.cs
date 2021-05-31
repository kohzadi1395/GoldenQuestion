using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.Option;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class OptionRepository : Repository<Option>, IOptionRepository
    {
        private readonly ApiContext _context;

        public OptionRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Option> GetAllOptions()
        {
            return GetAll();
        }

        public Option GetOption(Guid id)
        {
            return GetById(id);
        }

        public Option AddOption(Option option, Expression<Func<Option, bool>> predicate = null)
        {
            Add(option, predicate);
            return option;
        }

        public bool RemoveOption(Option option)
        {
            try
            {
                Remove(option);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveOption(Expression<Func<Option, bool>> criteria)
        {
            try
            {
                Remove(criteria);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateOption(Option option)
        {
            try
            {
                Update(option);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}