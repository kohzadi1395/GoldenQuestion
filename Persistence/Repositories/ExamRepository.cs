using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.Exam;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public partial class ExamRepository : Repository<Exam>, IExamRepository
    {
        private readonly ApiContext _context;

        public ExamRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Exam> GetAllExams()
        {
            return GetAll();
        }

        public Exam GetExam(Guid id)
        {
            return GetById(id);
        }

        public Exam AddExam(Exam exam, Expression<Func<Exam, bool>> predicate = null)
        {
            Add(exam, predicate);
            return exam;
        }

        public bool RemoveExam(Exam exam)
        {
            try
            {
                Remove(exam);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveExam(Expression<Func<Exam, bool>> criteria)
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

        public bool UpdateExam(Exam exam)
        {
            try
            {
                Update(exam);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}