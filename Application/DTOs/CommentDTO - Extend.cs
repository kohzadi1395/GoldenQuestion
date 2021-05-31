
using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTOs
{
    public partial class CommentDto : Comment
    {
        public Learning Learning { get; set; }
        public Exam Exam { get; set; }
        public UserDto User { get; set; }
        
        public static CommentDto GetDto(Comment comment, Learning learn, Exam exam,UserDto user)
        {
            return new CommentDto
            {
                CommentText = comment.CommentText,
                CreateDate = comment.CreateDate,
                CreateUser = comment.CreateUser,
                Deleted = comment.Deleted,
                IsApproved = comment.IsApproved,
                Id = comment.Id,
                ModifyDate = comment.ModifyDate,
                ModifyUser = comment.ModifyUser,
                RowVersion = comment.RowVersion,
                TableId = comment.TableId,
                TableType = comment.TableType,
                Exam = exam,
                Learning = learn,
                User = user
            };
        }
    }
}