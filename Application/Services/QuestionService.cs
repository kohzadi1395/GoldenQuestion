using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.ExamQuestion;
using Application.Interfaces.General;
using Application.Interfaces.Question;
using Domain.Entities;

namespace Application.Services
{
    public partial class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository, IUtilities utilities,
            IExamQuestionService examQuestionService)
        {
            _questionRepository = questionRepository;
            _examQuestionService = examQuestionService;
            _utilities = utilities;
        }

        public IEnumerable<QuestionDto> GetAllQuestions()
        {
            var questions = _questionRepository.GetAll().Select(x =>
            {
                return QuestionDto.GetDto(x);
            });
           
            return questions;
        }

        public Question GetQuestion(Guid id)
        {
            return _questionRepository.GetById(id);
        }

        public Question AddQuestion(Question question, Expression<Func<Question, bool>> predicate = null)
        {
            return _questionRepository.AddQuestion(question, predicate);
        }

        public bool RemoveQuestion(Question question)
        {
            return _questionRepository.RemoveQuestion(question);
        }

        public bool RemoveQuestion(Expression<Func<Question, bool>> predicate)
        {
            return _questionRepository.RemoveQuestion(predicate);
        }

        public bool UpdateQuestion(Question question)
        {
            return _questionRepository.UpdateQuestion(question);
        }

        public IEnumerable<Question> Find(Expression<Func<Question, bool>> criteria)
        {
            return _questionRepository.Find(criteria);
        }
    }
}