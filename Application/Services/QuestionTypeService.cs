using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.QuestionType;
using Domain.Entities;

namespace Application.Services
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;

        public QuestionTypeService(IQuestionTypeRepository questionTypeRepository)
        {
            _questionTypeRepository = questionTypeRepository;
        }

        public IEnumerable<QuestionTypeDto> GetAllQuestionTypes()
        {
            var questionTypes = _questionTypeRepository.GetAll().Select(x => new QuestionTypeDto
            {
                Name = x.Name,
                Questions = x.Questions,
                Id = x.Id,
                CreateUser = x.CreateUser,
                CreateDate = x.CreateDate,
                ModifyUser = x.ModifyUser,
                ModifyDate = x.ModifyDate,
                Deleted = x.Deleted,
                RowVersion = x.RowVersion
            });
            return questionTypes;
        }

        public QuestionType GetQuestionType(Guid id)
        {
            return _questionTypeRepository.GetById(id);
        }

        public QuestionType AddQuestionType(QuestionType questionType,
            Expression<Func<QuestionType, bool>> predicate = null)
        {
            return _questionTypeRepository.AddQuestionType(questionType, predicate);
        }

        public bool RemoveQuestionType(QuestionType questionType)
        {
            return _questionTypeRepository.RemoveQuestionType(questionType);
        }

        public bool RemoveQuestionType(Expression<Func<QuestionType, bool>> predicate)
        {
            return _questionTypeRepository.RemoveQuestionType(predicate);
        }

        public bool UpdateQuestionType(QuestionType questionType)
        {
            return _questionTypeRepository.UpdateQuestionType(questionType);
        }

        public IEnumerable<QuestionType> Find(Expression<Func<QuestionType, bool>> criteria)
        {
            return _questionTypeRepository.Find(criteria);
        }
    }
}