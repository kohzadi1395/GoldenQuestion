using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.ReportDTO;
using Application.QTO;
using Domain.Entities;
using LinqKit;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public partial class LearningRepository
    {
        public DataTransferObject<LearningDto> GetMainPageLearning(DataTransferObject<LearningDto> dataTransferObject)
        {
            var learnings = _context.Learnings
                .Where(x => x.Deleted == false)
                .Where(x => x.ProjectId == dataTransferObject.FilterDto.ProjectId)
                .Select(learning => new Learning
                {
                    Content = learning.Content,
                    CreateDate = learning.CreateDate,
                    CreateUser = learning.CreateUser,
                    Id = learning.Id,
                    Image = learning.Image,
                    IsFree = learning.IsFree,
                    LanguageId = learning.LanguageId,
                    Tags = learning.Tags,
                    Title = learning.Title
                });
            var result = AdditionalInformation(learnings, dataTransferObject);
            dataTransferObject.Result = result.Result;

            return dataTransferObject;
        }

        public DataTransferObject<LearningDto> GetMyLearning(DataTransferObject<LearningDto> dataTransferObject)
        {
            var learnings = _context.Learnings
                .Where(x => x.Deleted == false)
                .Where(x => x.ProjectId == dataTransferObject.FilterDto.ProjectId)
                .Where(x => x.CreateUser == dataTransferObject.FilterDto.UserId)
                .Select(learning => new Learning
                {
                    Content = learning.Content,
                    CreateDate = learning.CreateDate,
                    CreateUser = learning.CreateUser,
                    Id = learning.Id,
                    Image = learning.Image,
                    IsFree = learning.IsFree,
                    LanguageId = learning.LanguageId,
                    Tags = learning.Tags,
                    Title = learning.Title
                });
            var result = AdditionalInformation(learnings, dataTransferObject);
            dataTransferObject.Result = result.Result;

            return dataTransferObject;
        }

        public DataTransferObject<LearningDto> GetLearning(DataTransferObject<LearningDto> dataTransferObject)
        {
            var learnings = _context.Learnings
                .Where(x => x.Id == dataTransferObject.FilterDto.TableId)
                .Where(x => x.Deleted == false)
                .Where(x => x.ProjectId == dataTransferObject.FilterDto.ProjectId);

            var result = AdditionalInformation(learnings, dataTransferObject);
            dataTransferObject.Result = result.Result;
            return dataTransferObject;
        }

        private Task<List<LearningDto>> AdditionalInformation(IQueryable<Learning> learnings,
            DataTransferObject<LearningDto> dataTransferObject)
        {
            var rateQueries = _context.RateScores.Where(x => x.Deleted == false && x.TableType == TableType.Learning)
                .GroupBy(x => x.TableId).Select(x => new
                {
                    TableId = x.Key,
                    Average = x.Average(c => c.Rate)
                });
            var viewQueries = _context.LikeViews.Where(x => x.Deleted == false && x.TableType == TableType.Learning)
                .Where(c => c.LikeViewType == LikeViewType.View).GroupBy(x => x.TableId).Select(x => new
                {
                    TableId = x.Key,
                    View = x.Count()
                });
            var likeQueries = _context.LikeViews.Where(x => x.Deleted == false && x.TableType == TableType.Learning)
                .Where(c => c.LikeViewType == LikeViewType.Like).GroupBy(x => x.TableId).Select(x => new
                {
                    TableId = x.Key,
                    Like = x.Count()
                });

            var commentQueries = _context.Comments.Where(x => x.Deleted == false && x.TableType == TableType.Learning)
                .GroupBy(x => x.TableId).Select(x => new
                {
                    TableId = x.Key,
                    commentNumber = x.Count()
                });


            var learnDtos = from learning in learnings
                            join like in likeQueries on learning.Id equals like.TableId into learningLike
                            from like in learningLike.DefaultIfEmpty()
                            join view in viewQueries on learning.Id equals view.TableId into learningView
                            from view in learningView.DefaultIfEmpty()
                            join rate in rateQueries on learning.Id equals rate.TableId into learningRate
                            from rate in learningRate.DefaultIfEmpty()
                            join commentNumber in commentQueries on learning.Id equals commentNumber.TableId into
                                learningCommentNumber
                            from commentNumber in learningCommentNumber.DefaultIfEmpty()
                            select LearningDto.GetDto(learning,
                                like.Like,
                                view.View,
                                rate.Average,
                                commentNumber.commentNumber);
            var list = PagedResult(learnDtos, dataTransferObject, x => x.CreateDate, false).ToListAsync();
            return list;
        }

        #region SP

        public IEnumerable<LearningQto> GetLearning(PaginationDto paginationDto, Guid projectId, Guid learnId = default)
        {
            var startRowIndex = new SqlParameter
            {
                ParameterName = "startRowIndex",
                Value = paginationDto.PageNum - 1 > 0 ? paginationDto.PageNum - 1 : 0,
                Size = int.MaxValue,
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input
            };

            var pageSize = new SqlParameter
            {
                ParameterName = "pageSize",
                Value = paginationDto.PageSize > 0 ? paginationDto.PageSize : 10,
                Size = int.MaxValue,
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input
            };

            var learnIdParam = new SqlParameter
            {
                ParameterName = "learnId",
                Value = learnId,
                Size = int.MaxValue,
                DbType = DbType.Guid,
                Direction = ParameterDirection.Input
            };
            var projectIdParam = new SqlParameter
            {
                ParameterName = "projectId",
                Value = projectId,
                Size = int.MaxValue,
                DbType = DbType.Guid,
                Direction = ParameterDirection.Input
            };

            var totalCount = new SqlParameter
            {
                ParameterName = "totalCount",
                Size = int.MaxValue,
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };

            var fromSqlRaw = _context.Set<LearningQto>()
                .FromSqlRaw(@"EXEC [GetLearn]
                            @startRowIndex, @pageSize, @learnId,@projectId, @totalCount OUTPUT",
                    startRowIndex,
                    pageSize,
                    learnIdParam,
                    projectIdParam,
                    totalCount).ToList();

            return fromSqlRaw;
        }

        public IEnumerable<LearningQto> GetMainPageLearning_SP(PaginationDto paginationDto, Guid projectId,
            Guid learnId = default)
        {
            var startRowIndex = new SqlParameter
            {
                ParameterName = "startRowIndex",
                Value = paginationDto.PageNum - 1 > 0 ? paginationDto.PageNum - 1 : 0,
                Size = int.MaxValue,
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input
            };

            var pageSize = new SqlParameter
            {
                ParameterName = "pageSize",
                Value = paginationDto.PageSize > 0 ? paginationDto.PageSize : 10,
                Size = int.MaxValue,
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input
            };

            var learnIdParam = new SqlParameter
            {
                ParameterName = "learnId",
                Value = Guid.Empty,
                Size = int.MaxValue,
                DbType = DbType.Guid,
                Direction = ParameterDirection.Input
            };
            var projectIdParam = new SqlParameter
            {
                ParameterName = "projectId",
                Value = projectId,
                Size = int.MaxValue,
                DbType = DbType.Guid,
                Direction = ParameterDirection.Input
            };
            var totalCount = new SqlParameter
            {
                ParameterName = "totalCount",
                Size = int.MaxValue,
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };

            var fromSqlRaw = _context.Set<LearningQto>()
                .FromSqlRaw(@"EXEC [GetMainPageLearning]
                            @startRowIndex, @pageSize, @learnId, @projectId, @totalCount OUTPUT",
                    startRowIndex,
                    pageSize,
                    learnIdParam,
                    projectIdParam,
                    totalCount).ToList();

            return fromSqlRaw;
        }

        public DataTransferObject<LearningDto> GetSearch(DataTransferObject<LearningDto> dataTransferObject)
        {
            var learnings = _context.Learnings
                .Where(x => x.Deleted == false)
                .Where(x => x.ProjectId == dataTransferObject.FilterDto.ProjectId);


            var predicate = PredicateBuilder.False<Learning>();
            if (dataTransferObject.FilterDto.Tags != null)
            {
                foreach (var keyword in dataTransferObject.FilterDto.Tags.Split(new[] { ",", ";" },
                    StringSplitOptions.None))
                    predicate = predicate.Or(p => p.Tags.Contains(keyword.Trim()));
            }

            if (string.IsNullOrEmpty(dataTransferObject.FilterDto.Title) == false)
                predicate = predicate.Or(x => x.Title.Contains(dataTransferObject.FilterDto.Title));

            if (string.IsNullOrEmpty(dataTransferObject.FilterDto.Content) == false)
                predicate = predicate.Or(x => x.Content.Contains(dataTransferObject.FilterDto.Content));
            learnings = learnings.Where(predicate);

            var result = AdditionalInformation(learnings, dataTransferObject);
            dataTransferObject.Result = result.Result;

            return dataTransferObject;
        }

        #endregion
    }
}