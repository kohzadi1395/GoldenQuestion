using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;

namespace Application.Interfaces.Language
{
    public interface ILanguageService
    {
        IEnumerable<LanguageDto> GetAllLanguages();
        Domain.Entities.Language GetLanguage(Guid id);

        Domain.Entities.Language AddLanguage(Domain.Entities.Language language,
            Expression<Func<Domain.Entities.Language, bool>> predicate = null);

        bool RemoveLanguage(Expression<Func<Domain.Entities.Language, bool>> predicate);
        bool RemoveLanguage(Domain.Entities.Language language);
        bool UpdateLanguage(Domain.Entities.Language language);
        IEnumerable<Domain.Entities.Language> Find(Expression<Func<Domain.Entities.Language, bool>> criteria);
    }
}