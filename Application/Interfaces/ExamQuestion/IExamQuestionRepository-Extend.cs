using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.General;

namespace Application.Interfaces.ExamQuestion
{
    public partial interface IExamQuestionRepository
    {
        List<Domain.Entities.Question> GetQuestions(Guid examId);
    }
}