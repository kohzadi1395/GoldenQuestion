using System;
using System.Collections.Generic;
using Domain.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.DTOs
{
    public class ExamMongo
    {
        [BsonId] public Guid Id { get; set; }
        public  Exam Exam{ get; set; }
        public List<QuesDto> Questions { get; set; }
        public int CorrectAnswer { get; set; }
        public int WrongAnswer { get; set; }
        public decimal PercentCorrectAnswer { get; set; }
        public decimal PercentWrongAnswer { get; set; }
        public Guid StudentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

    }

    public class QuesDto
    {
        [BsonId] public Guid Id { get; set; }
        public Question Question { get; set; }
        public Guid? UserAnswer { get; set; }
        public List<Guid> UserAnswers { get; set; }
        public bool IsCorrect { get; set; }
        public List<OpDto> Options { get; set; }
    }

    public class OpDto
    {
        [BsonId] public Guid Id { get; set; }
        public Option Option { get; set; }
        public bool IsSelected { get; set; }
    }
}