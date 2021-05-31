using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.General;

namespace Application.Interfaces.QuestionType
{
    public interface IQuestionTypeRepository : IRepository<Domain.Entities.QuestionType>
    {
        IEnumerable<Domain.Entities.QuestionType> GetAllQuestionTypes();
        Domain.Entities.QuestionType GetQuestionType(Guid id);

        Domain.Entities.QuestionType AddQuestionType(Domain.Entities.QuestionType questionType,
            Expression<Func<Domain.Entities.QuestionType, bool>> predicate = null);

        bool RemoveQuestionType(Expression<Func<Domain.Entities.QuestionType, bool>> criteria);
        bool RemoveQuestionType(Domain.Entities.QuestionType questionType);
        bool UpdateQuestionType(Domain.Entities.QuestionType questionType);
    }
}