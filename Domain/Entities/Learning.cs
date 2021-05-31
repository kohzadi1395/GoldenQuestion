using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Security.Application;

namespace Domain.Entities
{
    public class Learning : BaseEntity
    {
        private string _html;

        public string Html
        {
            get => _html;
            //set => _html = Sanitizer.GetSafeHtml(value);
            set => _html = value;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public byte[] Image { get; set; }

        public string Tags { get; set; }

        [ForeignKey("Language")] public Guid LanguageId { get; set; }

        public Language Language { get; set; }

        public bool IsPublic { get; set; }

        public bool IsFree { get; set; }
        public bool IsCommentNeedApprove { get; set; }
        public bool AllowComment { get; set; }
        
        public Guid? ProjectId { get; set; }

    }
}