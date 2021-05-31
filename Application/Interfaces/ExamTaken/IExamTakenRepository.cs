using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.General;

namespace Application.Interfaces.ExamTaken
{
    public interface IExamTakenRepository : IRepository<Domain.Entities.ExamTaken>
    {
        IEnumerable<Domain.Entities.ExamTaken> GetAllExamTakens();
        Domain.Entities.ExamTaken GetExamTaken(Guid id);

        Domain.Entities.ExamTaken AddExamTaken(Domain.Entities.ExamTaken examTaken,
            Expression<Func<Domain.Entities.ExamTaken, bool>> predicate = null);

        bool RemoveExamTaken(Expression<Func<Domain.Entities.ExamTaken, bool>> criteria);
        bool RemoveExamTaken(Domain.Entities.ExamTaken examTaken);
        bool UpdateExamTaken(Domain.Entities.ExamTaken examTaken);
    }
}