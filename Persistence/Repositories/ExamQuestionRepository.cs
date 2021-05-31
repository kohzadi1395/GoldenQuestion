using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.ExamQuestion;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public partial class ExamQuestionRepository : Repository<ExamQuestion>, IExamQuestionRepository
    {
        private readonly ApiContext _context;

        public ExamQuestionRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public ExamQuestion GetExamQuestion(Guid id)
        {
            return GetById(id);
        }

        public IEnumerable<ExamQuestion> GetAllExamQuestions()
        {
            return GetAll();
        }



        public ExamQuestion AddExamQuestion(ExamQuestion examQuestion,
            Expression<Func<ExamQuestion, bool>> predicate = null)
        {
            Add(examQuestion, predicate);
            return examQuestion;
        }

        public bool RemoveExamQuestion(ExamQuestion examQuestion)
        {
            try
            {
                Remove(x=>x.ExamId==examQuestion.ExamId&& x.QuestionId==examQuestion.QuestionId);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveExamQuestion(Expression<Func<ExamQuestion, bool>> criteria)
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

        public bool UpdateExamQuestion(ExamQuestion examQuestion)
        {
            try
            {
                Update(examQuestion);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}