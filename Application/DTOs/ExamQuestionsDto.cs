using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTOs
{
    public class ExamQuestionsDto
    {
        public ExamDto Exam { get; set; }
        public List<Question> Questions { get; set; }
    }
}