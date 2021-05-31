using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.General;

namespace Application.Interfaces.ExamQuestion
{
    public partial interface IExamQuestionRepository : IRepository<Domain.Entities.ExamQuestion>
    {
        IEnumerable<Domain.Entities.ExamQuestion> GetAllExamQuestions();
        Domain.Entities.ExamQuestion GetExamQuestion(Guid id);

        Domain.Entities.ExamQuestion AddExamQuestion(Domain.Entities.ExamQuestion examQuestion,
            Expression<Func<Domain.Entities.ExamQuestion, bool>> predicate = null);

        bool RemoveExamQuestion(Expression<Func<Domain.Entities.ExamQuestion, bool>> criteria);
        bool RemoveExamQuestion(Domain.Entities.ExamQuestion examQuestion);
        bool UpdateExamQuestion(Domain.Entities.ExamQuestion examQuestion);
    }
}