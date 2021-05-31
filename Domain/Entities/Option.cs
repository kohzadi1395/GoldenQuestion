using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Security.Application;

namespace Domain.Entities
{
    public class Option : BaseEntity
    {
        private string _html;

        public string Html
        {
            get => _html;
            //set => _html = Sanitizer.GetSafeHtml(value);
            set => _html = value;
        }

        public bool CorrectOption { get; set; }

        [ForeignKey("Question")] public Guid QuestionId { get; set; }

        public Question Question { get; set; }
    }
}