using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.Language;
using Domain.Entities;

namespace Application.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public IEnumerable<LanguageDto> GetAllLanguages()
        {
            var languages = _languageRepository.GetAll().Select(x => new LanguageDto
            {
                Name = x.Name,
                Abbreviation = x.Abbreviation,
                Icon = x.Icon,
                Questions = x.Questions,
                Learnings = x.Learnings,
                Id = x.Id,
                CreateUser = x.CreateUser,
                CreateDate = x.CreateDate,
                ModifyUser = x.ModifyUser,
                ModifyDate = x.ModifyDate,
                Deleted = x.Deleted,
                RowVersion = x.RowVersion
            });
            return languages;
        }

        public Language GetLanguage(Guid id)
        {
            return _languageRepository.GetById(id);
        }

        public Language AddLanguage(Language language, Expression<Func<Language, bool>> predicate = null)
        {
            return _languageRepository.AddLanguage(language, predicate);
        }

        public bool RemoveLanguage(Language language)
        {
            return _languageRepository.RemoveLanguage(language);
        }

        public bool RemoveLanguage(Expression<Func<Language, bool>> predicate)
        {
            return _languageRepository.RemoveLanguage(predicate);
        }

        public bool UpdateLanguage(Language language)
        {
            return _languageRepository.UpdateLanguage(language);
        }

        public IEnumerable<Language> Find(Expression<Func<Language, bool>> criteria)
        {
            return _languageRepository.Find(criteria);
        }
    }
}