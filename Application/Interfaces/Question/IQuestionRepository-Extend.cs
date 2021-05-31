using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Interfaces.Question
{
    public partial interface IQuestionRepository
    {
        ICollection<Domain.Entities.Question> GetRandomQuestions(int questionNumber);
        List<Domain.Entities.Question> GetAllWithOption(Expression<Func<Domain.Entities.Question, bool>> predicate = null);
    }
}