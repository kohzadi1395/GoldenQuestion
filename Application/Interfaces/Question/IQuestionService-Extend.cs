using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces.Question
{
    public partial interface IQuestionService
    {
        ICollection<Domain.Entities.Question> GetRandomQuestions(int questionNumber);
        List<Domain.Entities.Question> GetQuestions(Expression<Func<Domain.Entities.Question, bool>> criteria = null);
        Domain.Entities.Question AddQuestion(QuestionDto questionDto);
        bool UpdateQuestion(QuestionDto questionDto);
        Task<bool> AddExamQuestions(List<Domain.Entities.Question> question, ExamDto exam);
        Task<bool> UpdateExamQuestions(List<Domain.Entities.Question> question, ExamDto exam);
    }
}