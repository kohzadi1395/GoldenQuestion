using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.General;

namespace Application.Interfaces.Learning
{
    public partial interface ILearningRepository : IRepository<Domain.Entities.Learning>
    {
        IEnumerable<Domain.Entities.Learning> GetAllLearnings();

        Domain.Entities.Learning AddLearning(Domain.Entities.Learning learning,
            Expression<Func<Domain.Entities.Learning, bool>> predicate = null);

        bool RemoveLearning(Expression<Func<Domain.Entities.Learning, bool>> criteria);
        bool RemoveLearning(Domain.Entities.Learning learning);
        bool UpdateLearning(Domain.Entities.Learning learning);
    }
}