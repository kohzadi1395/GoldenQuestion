using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;

namespace Application.Interfaces.ExamTaken
{
    public interface IExamTakenService
    {
        IEnumerable<ExamTakenDto> GetAllExamTakens();
        Domain.Entities.ExamTaken GetExamTaken(Guid id);

        Domain.Entities.ExamTaken AddExamTaken(Domain.Entities.ExamTaken examTaken,
            Expression<Func<Domain.Entities.ExamTaken, bool>> predicate = null);

        bool RemoveExamTaken(Expression<Func<Domain.Entities.ExamTaken, bool>> predicate);
        bool RemoveExamTaken(Domain.Entities.ExamTaken examTaken);
        bool UpdateExamTaken(Domain.Entities.ExamTaken examTaken);
        IEnumerable<Domain.Entities.ExamTaken> Find(Expression<Func<Domain.Entities.ExamTaken, bool>> criteria);
    }
}