using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ExamTaken : BaseEntity
    {
        public DateTime TakeExam { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("Exam")] 
        public Guid ExamId { get; set; }

        public Exam Exam { get; set; }
    }
}