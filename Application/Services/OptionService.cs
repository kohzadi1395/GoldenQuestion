using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.Option;
using Domain.Entities;

namespace Application.Services
{
    public partial class OptionService : IOptionService
    {
        private readonly IOptionRepository _optionRepository;

        public OptionService(IOptionRepository optionRepository)
        {
            _optionRepository = optionRepository;
        }

        public IEnumerable<OptionDto> GetAllOptions()
        {
            var options = _optionRepository.GetAll().Select(x => new OptionDto
            {
                Html = x.Html,
                CorrectOption = x.CorrectOption,
                QuestionId = x.QuestionId,
                Question = x.Question,
                Id = x.Id,
                CreateUser = x.CreateUser,
                CreateDate = x.CreateDate,
                ModifyUser = x.ModifyUser,
                ModifyDate = x.ModifyDate,
                Deleted = x.Deleted,
                RowVersion = x.RowVersion
            });
            return options;
        }

        public Option GetOption(Guid id)
        {
            return _optionRepository.GetById(id);
        }

        public Option AddOption(Option option, Expression<Func<Option, bool>> predicate = null)
        {
            return _optionRepository.AddOption(option, predicate);
        }

        public bool RemoveOption(Option option)
        {
            return _optionRepository.RemoveOption(option);
        }

        public bool RemoveOption(Expression<Func<Option, bool>> predicate)
        {
            return _optionRepository.RemoveOption(predicate);
        }

        public bool UpdateOption(Option option)
        {
            return _optionRepository.UpdateOption(option);
        }

        public IEnumerable<Option> Find(Expression<Func<Option, bool>> criteria)
        {
            return _optionRepository.Find(criteria);
        }
    }
}