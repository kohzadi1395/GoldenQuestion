using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.General;

namespace Application.Interfaces.Question
{
    public partial interface IQuestionRepository : IRepository<Domain.Entities.Question>
    {
        IEnumerable<Domain.Entities.Question> GetAllQuestions();
        Domain.Entities.Question GetQuestion(Guid id);

        Domain.Entities.Question AddQuestion(Domain.Entities.Question question,
            Expression<Func<Domain.Entities.Question, bool>> predicate = null);

        bool RemoveQuestion(Expression<Func<Domain.Entities.Question, bool>> criteria);
        bool RemoveQuestion(Domain.Entities.Question question);
        bool UpdateQuestion(Domain.Entities.Question question);
    }
}