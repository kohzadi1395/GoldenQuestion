using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;

namespace Application.Interfaces.ExamQuestion
{
    public partial interface IExamQuestionService
    {
        IEnumerable<ExamQuestionDto> GetAllExamQuestions();
        Domain.Entities.ExamQuestion GetExamQuestion(Guid id);

        Domain.Entities.ExamQuestion AddExamQuestion(Domain.Entities.ExamQuestion examQuestion,
            Expression<Func<Domain.Entities.ExamQuestion, bool>> predicate = null);

        bool RemoveExamQuestion(Expression<Func<Domain.Entities.ExamQuestion, bool>> predicate);
        bool RemoveExamQuestion(Domain.Entities.ExamQuestion examQuestion);
        bool UpdateExamQuestion(Domain.Entities.ExamQuestion examQuestion);
        IEnumerable<Domain.Entities.ExamQuestion> Find(Expression<Func<Domain.Entities.ExamQuestion, bool>> criteria);
    }
}