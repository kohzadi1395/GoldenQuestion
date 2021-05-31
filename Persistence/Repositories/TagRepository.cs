using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.Tag;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private readonly ApiContext _context;

        public TagRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return GetAll();
        }

        public Tag GetTag(Guid id)
        {
            return GetById(id);
        }

        public Tag AddTag(Tag tag, Expression<Func<Tag, bool>> predicate = null)
        {
            Add(tag, predicate);
            return tag;
        }

        public bool RemoveTag(Tag tag)
        {
            try
            {
                Remove(tag);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveTag(Expression<Func<Tag, bool>> criteria)
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

        public bool UpdateTag(Tag tag)
        {
            try
            {
                Update(tag);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}