
using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTOs
{
    public partial class LearningDto : Learning
    {
        public Learning Mapper()
        {
            return new Learning
            {
				AllowComment = AllowComment,
				Content = Content,
				CreateDate = CreateDate,
				CreateUser = CreateUser,
				Deleted = Deleted,
				Html = Html,
				Id = Id,
				Image = Image,
				IsCommentNeedApprove = IsCommentNeedApprove,
				IsFree = IsFree,
				IsPublic = IsPublic,
				Language = Language,
				LanguageId = LanguageId,
				ModifyDate = ModifyDate,
				ModifyUser = ModifyUser,
				ProjectId = ProjectId,
				RowVersion = RowVersion,
				Tags = Tags,
				Title = Title
            };
        }
        public static LearningDto GetDto(Learning learning)
        {
            return new LearningDto
            {
				AllowComment = learning.AllowComment,
				Content = learning.Content,
				CreateDate = learning.CreateDate,
				CreateUser = learning.CreateUser,
				Deleted = learning.Deleted,
				Html = learning.Html,
				Id = learning.Id,
				Image = learning.Image,
				IsCommentNeedApprove = learning.IsCommentNeedApprove,
				IsFree = learning.IsFree,
				IsPublic = learning.IsPublic,
				Language = learning.Language,
				LanguageId = learning.LanguageId,
				ModifyDate = learning.ModifyDate,
				ModifyUser = learning.ModifyUser,
				ProjectId = learning.ProjectId,
				RowVersion = learning.RowVersion,
				Tags = learning.Tags,
				Title = learning.Title,

            };
        }
        
    }
}