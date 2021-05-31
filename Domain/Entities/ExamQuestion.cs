using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ExamQuestion : BaseEntity
    {
        public int QuestionNumber { get; set; }

        [ForeignKey("Question")] public Guid QuestionId { get; set; }

        public Question Question { get; set; }

        [ForeignKey("Exam")] public Guid ExamId { get; set; }

        public Exam Exam { get; set; }
    }
}