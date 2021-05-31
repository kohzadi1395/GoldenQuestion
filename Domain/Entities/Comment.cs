using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Security.Application;

namespace Domain.Entities
{
    public class Comment : BaseEntity
    {
        public Guid TableId { get; set; }

        //Learning,Exam
        public TableType TableType { get; set; }

        [MaxLength(500)]
        public string CommentText { get; set; }

        public bool? IsApproved { get; set; } = false;
    }
}