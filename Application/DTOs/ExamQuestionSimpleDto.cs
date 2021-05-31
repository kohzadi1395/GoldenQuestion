using System;
using Domain.Entities;

namespace Application.DTOs
{
    public class ExamQuestionSimpleDto
    {
        public Guid ExamId { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}