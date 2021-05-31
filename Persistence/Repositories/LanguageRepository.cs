using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.Language;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        private readonly ApiContext _context;

        public LanguageRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Language> GetAllLanguages()
        {
            return GetAll();
        }

        public Language GetLanguage(Guid id)
        {
            return GetById(id);
        }

        public Language AddLanguage(Language language, Expression<Func<Language, bool>> predicate = null)
        {
            Add(language, predicate);
            return language;
        }

        public bool RemoveLanguage(Language language)
        {
            try
            {
                Remove(language);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveLanguage(Expression<Func<Language, bool>> criteria)
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

        public bool UpdateLanguage(Language language)
        {
            try
            {
                Update(language);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}