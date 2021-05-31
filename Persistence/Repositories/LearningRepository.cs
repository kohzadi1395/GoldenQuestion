using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;
using Application.DTOs.ReportDTO;
using Application.Interfaces.Learning;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public partial class LearningRepository : Repository<Learning>, ILearningRepository
    {
        private readonly ApiContext _context;

        public LearningRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Learning> GetAllLearnings()
        {
            return GetAll();
        }

        public Learning AddLearning(Learning learning, Expression<Func<Learning, bool>> predicate = null)
        {
            Add(learning, predicate);
            return learning;
        }

        public bool RemoveLearning(Learning learning)
        {
            try
            {
                Remove(learning);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveLearning(Expression<Func<Learning, bool>> criteria)
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

        public bool UpdateLearning(Learning learning)
        {
            try
            {
                Update(learning);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}