using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;

namespace Application.Interfaces.Question
{
    public partial interface IQuestionService
    {
        Domain.Entities.Question GetQuestion(Guid id);

        Domain.Entities.Question AddQuestion(Domain.Entities.Question question,
            Expression<Func<Domain.Entities.Question, bool>> predicate = null);

        bool RemoveQuestion(Expression<Func<Domain.Entities.Question, bool>> predicate);
        bool RemoveQuestion(Domain.Entities.Question question);
        bool UpdateQuestion(Domain.Entities.Question question);
        IEnumerable<Domain.Entities.Question> Find(Expression<Func<Domain.Entities.Question, bool>> criteria);
    }
}