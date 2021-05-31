using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.QuestionType;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class QuestionTypeRepository : Repository<QuestionType>, IQuestionTypeRepository
    {
        private readonly ApiContext _context;

        public QuestionTypeRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<QuestionType> GetAllQuestionTypes()
        {
            return GetAll();
        }

        public QuestionType GetQuestionType(Guid id)
        {
            return GetById(id);
        }

        public QuestionType AddQuestionType(QuestionType questionType,
            Expression<Func<QuestionType, bool>> predicate = null)
        {
            Add(questionType, predicate);
            return questionType;
        }

        public bool RemoveQuestionType(QuestionType questionType)
        {
            try
            {
                Remove(questionType);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveQuestionType(Expression<Func<QuestionType, bool>> criteria)
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

        public bool UpdateQuestionType(QuestionType questionType)
        {
            try
            {
                Update(questionType);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}