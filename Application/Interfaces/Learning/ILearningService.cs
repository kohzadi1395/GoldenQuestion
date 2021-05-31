using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Interfaces.Learning
{
    public partial interface ILearningService
    {
        Domain.Entities.Learning AddLearning(Domain.Entities.Learning learning,
            Expression<Func<Domain.Entities.Learning, bool>> predicate = null);

        bool RemoveLearning(Expression<Func<Domain.Entities.Learning, bool>> predicate);
        bool RemoveLearning(Domain.Entities.Learning learning);
        bool UpdateLearning(Domain.Entities.Learning learning);
        IEnumerable<Domain.Entities.Learning> Find(Expression<Func<Domain.Entities.Learning, bool>> criteria);
    }
}