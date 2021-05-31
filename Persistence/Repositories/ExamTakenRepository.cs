using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.ExamTaken;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class ExamTakenRepository : Repository<ExamTaken>, IExamTakenRepository
    {
        private readonly ApiContext _context;

        public ExamTakenRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ExamTaken> GetAllExamTakens()
        {
            return GetAll();
        }

        public ExamTaken GetExamTaken(Guid id)
        {
            return GetById(id);
        }

        public ExamTaken AddExamTaken(ExamTaken examTaken, Expression<Func<ExamTaken, bool>> predicate = null)
        {
            Add(examTaken, predicate);
            return examTaken;
        }

        public bool RemoveExamTaken(ExamTaken examTaken)
        {
            try
            {
                Remove(examTaken);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveExamTaken(Expression<Func<ExamTaken, bool>> criteria)
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

        public bool UpdateExamTaken(ExamTaken examTaken)
        {
            try
            {
                Update(examTaken);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}