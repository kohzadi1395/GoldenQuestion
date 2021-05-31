
using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTOs
{
    public partial class CommentDto : Comment
    {
        public Comment Mapper()
        {
            return new Comment
            {
				CommentText = CommentText,
				CreateDate = CreateDate,
				CreateUser = CreateUser,
				Deleted = Deleted,
				IsApproved = IsApproved,
				Id = Id,
				ModifyDate = ModifyDate,
				ModifyUser = ModifyUser,
				RowVersion = RowVersion,
				TableId = TableId,
				TableType = TableType
            };
        }
        public static CommentDto GetDto(Comment comment)
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

            };
        }
        
    }
}