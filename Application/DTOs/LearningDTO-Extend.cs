using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
    public partial class LearningDto
    {
        [NotMapped]
        public IFormFile Picture { get; set; }
        public int? Like { get; set; }
        public int? View { get; set; }
        public double? Rate { get; set; }
        public int CommentNumber { get; set; }


        public static LearningDto GetDto(Learning learning, int? likeCount, int? viewCount, double? rateAverage, int commentNumber)
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
                Rate = rateAverage ?? 0,
                Like = likeCount ?? 0,
                View = viewCount ?? 0,
                CommentNumber = commentNumber
            };
        }

    }
}