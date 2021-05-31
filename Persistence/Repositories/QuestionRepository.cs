using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Interfaces.Question;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;

namespace Persistence.Repositories
{
    public partial class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly ApiContext _context;

        public QuestionRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            var questions = _context.Questions
                .AsNoTracking()
                .Include(x => x.Options.Where(y => y.Deleted == false));
            return questions;
        }

        public Question GetQuestion(Guid id)
        {
            var question = _context.Questions
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Options.Where(y => y.Deleted == false))
                .FirstOrDefault();
            return question;
        }

        public Question AddQuestion(Question question, Expression<Func<Question, bool>> predicate = null)
        {
            Add(question, predicate);
            return question;
        }

        public bool RemoveQuestion(Question question)
        {
            try
            {
                Remove(question);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveQuestion(Expression<Func<Question, bool>> criteria)
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

        public bool UpdateQuestion(Question question)
        {
            try
            {
                Update(question);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}