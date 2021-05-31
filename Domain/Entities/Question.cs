using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Security.Application;

namespace Domain.Entities
{
    public class Question : BaseEntity
    {
        private string _html;

        public string Html
        {
            get => _html;
            //set => _html = Sanitizer.GetSafeHtml(value);
            set => _html = value;
        }

        [ForeignKey("Language")] 
        public Guid LanguageId { get; set; }

        public Language Language { get; set; }

        [ForeignKey("State")] public Guid StateId { get; set; }

        public State State { get; set; }

        public string Tags { get; set; }

        public bool IsPublic { get; set; }

        [ForeignKey("QuestionType")] public Guid QuestionTypeId { get; set; }

        public QuestionType QuestionType { get; set; }

        public ICollection<Option> Options { get; set; } = new HashSet<Option>();
        public ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();
    }
}