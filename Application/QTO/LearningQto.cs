using System;
using System.ComponentModel.DataAnnotations.Schema;
using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Security.Application;

namespace Application.QTO
{
    public partial class LearningQto
    {
        [NotMapped]
        public IFormFile Picture { get; set; }
        public int? Like { get; set; }
        public int? View { get; set; }
        public double? Rate { get; set; }
        public int? CommentNumber { get; set; }
        private string? _html;
        public string? Html
        {
            get => _html;
           // set => _html = Sanitizer.GetSafeHtml(value);
            set => _html = value;
        }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public byte[]? Image { get; set; }
        public string? Tags { get; set; }
        public Guid? LanguageId { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsFree { get; set; }
        public bool? IsCommentNeedApprove { get; set; }
        public bool? AllowComment { get; set; }
        public Guid? ProjectId { get; set; }
     
    }
}