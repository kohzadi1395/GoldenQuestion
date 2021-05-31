using System;
using System.Collections.Generic;

namespace Application.Interfaces.ExamQuestion
{
    public partial interface IExamQuestionService
    {
        List<Domain.Entities.ExamQuestion> AddExamQuestion(Guid examId, List<Domain.Entities.Question> randomQuestions);
        List<Domain.Entities.Question> GetQuestions(Guid examId);

    }
}