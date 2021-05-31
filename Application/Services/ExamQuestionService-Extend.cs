using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.Services
{
    public partial class ExamQuestionService
    {
        public List<ExamQuestion> AddExamQuestion(Guid examId, List<Question> randomQuestions)
        {
            var examQuestions = new List<ExamQuestion>();
            for (var index = 0; index < randomQuestions.Count; index++)
            {
                var question = randomQuestions[index];
                var examQuestion = new ExamQuestion
                {
                    QuestionNumber = index + 1,
                    QuestionId = question.Id,
                    ExamId = examId
                };
                examQuestions.Add(examQuestion);
                _examQuestionRepository.AddExamQuestion(examQuestion);
            }

            return examQuestions;
        }
    }
}