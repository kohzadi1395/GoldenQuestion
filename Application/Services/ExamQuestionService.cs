using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.ExamQuestion;
using Domain.Entities;

namespace Application.Services
{
    public partial class ExamQuestionService : IExamQuestionService
    {
        private readonly IExamQuestionRepository _examQuestionRepository;

        public ExamQuestionService(IExamQuestionRepository examQuestionRepository)
        {
            _examQuestionRepository = examQuestionRepository;
        }

        public IEnumerable<ExamQuestionDto> GetAllExamQuestions()
        {
            var examQuestions = _examQuestionRepository.GetAll().Select(x => new ExamQuestionDto
            {
                QuestionNumber = x.QuestionNumber,
                QuestionId = x.QuestionId,
                Question = x.Question,
                ExamId = x.ExamId,
                Exam = x.Exam,
                Id = x.Id,
                CreateUser = x.CreateUser,
                CreateDate = x.CreateDate,
                ModifyUser = x.ModifyUser,
                ModifyDate = x.ModifyDate,
                Deleted = x.Deleted,
                RowVersion = x.RowVersion
            });
            return examQuestions;
        }

        public ExamQuestion GetExamQuestion(Guid id)
        {
            return _examQuestionRepository.GetById(id);
        }

        public ExamQuestion AddExamQuestion(ExamQuestion examQuestion,
            Expression<Func<ExamQuestion, bool>> predicate = null)
        {

            return _examQuestionRepository.AddExamQuestion(examQuestion, x=>x.ExamId==examQuestion.ExamId 
                                                                            && x.QuestionId==examQuestion.QuestionId);
        }

        public bool RemoveExamQuestion(ExamQuestion examQuestion)
        {
            return _examQuestionRepository.RemoveExamQuestion(examQuestion);
        }

        public bool RemoveExamQuestion(Expression<Func<ExamQuestion, bool>> predicate)
        {
            return _examQuestionRepository.RemoveExamQuestion(predicate);
        }

        public bool UpdateExamQuestion(ExamQuestion examQuestion)
        {
            return _examQuestionRepository.UpdateExamQuestion(examQuestion);
        }

        public IEnumerable<ExamQuestion> Find(Expression<Func<ExamQuestion, bool>> criteria)
        {
            return _examQuestionRepository.Find(criteria);
        }

        public List<Question> GetQuestions(Guid examId)
        {
            return _examQuestionRepository.GetQuestions(examId);
        }

    }
}