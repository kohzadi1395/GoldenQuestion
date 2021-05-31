using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;

namespace Application.Interfaces.QuestionType
{
    public interface IQuestionTypeService
    {
        IEnumerable<QuestionTypeDto> GetAllQuestionTypes();
        Domain.Entities.QuestionType GetQuestionType(Guid id);

        Domain.Entities.QuestionType AddQuestionType(Domain.Entities.QuestionType questionType,
            Expression<Func<Domain.Entities.QuestionType, bool>> predicate = null);

        bool RemoveQuestionType(Expression<Func<Domain.Entities.QuestionType, bool>> predicate);
        bool RemoveQuestionType(Domain.Entities.QuestionType questionType);
        bool UpdateQuestionType(Domain.Entities.QuestionType questionType);
        IEnumerable<Domain.Entities.QuestionType> Find(Expression<Func<Domain.Entities.QuestionType, bool>> criteria);
    }
}