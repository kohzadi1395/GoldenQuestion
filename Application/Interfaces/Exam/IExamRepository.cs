using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.General;

namespace Application.Interfaces.Exam
{
    public partial interface IExamRepository : IRepository<Domain.Entities.Exam>
    {
        IEnumerable<Domain.Entities.Exam> GetAllExams();
        Domain.Entities.Exam GetExam(Guid id);

        Domain.Entities.Exam AddExam(Domain.Entities.Exam exam,
            Expression<Func<Domain.Entities.Exam, bool>> predicate = null);

        bool RemoveExam(Expression<Func<Domain.Entities.Exam, bool>> criteria);
        bool RemoveExam(Domain.Entities.Exam exam);
        bool UpdateExam(Domain.Entities.Exam exam);
    }
}