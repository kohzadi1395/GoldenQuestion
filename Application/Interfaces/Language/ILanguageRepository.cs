using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.General;

namespace Application.Interfaces.Language
{
    public interface ILanguageRepository : IRepository<Domain.Entities.Language>
    {
        IEnumerable<Domain.Entities.Language> GetAllLanguages();
        Domain.Entities.Language GetLanguage(Guid id);

        Domain.Entities.Language AddLanguage(Domain.Entities.Language language,
            Expression<Func<Domain.Entities.Language, bool>> predicate = null);

        bool RemoveLanguage(Expression<Func<Domain.Entities.Language, bool>> criteria);
        bool RemoveLanguage(Domain.Entities.Language language);
        bool UpdateLanguage(Domain.Entities.Language language);
    }
}