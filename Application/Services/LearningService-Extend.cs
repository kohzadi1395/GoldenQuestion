using System;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.ReportDTO;
using Application.Interfaces.Comment;
using Application.Interfaces.General;
using Application.Interfaces.LikeView;
using Application.Interfaces.RateScore;
using Domain.Entities;

namespace Application.Services
{
    public partial class LearningService
    {
        private readonly ICommentService _commentService;
        private readonly ILikeViewService _likeViewService;
        private readonly IRateScoreService _rateScoreService;
        private readonly IUtilities _utilities;

        public async Task<Learning> AddLearning(LearningDto learningDto)
        {
            var learning = learningDto.Mapper();
            var savedFile = await _utilities.GetImage(learningDto.Id.ToString(), learningDto.Picture);
            if (savedFile != null)
                learning.Image = savedFile.File;
            var addLearning = _learningRepository.AddLearning(learning);
            return addLearning;
        }

        public async Task<bool> UpdateLearning(LearningDto learningDto)
        {
            var learning = learningDto.Mapper();
            var savedFile = await _utilities.GetImage(learningDto.Id.ToString(), learningDto.Picture);
            if (savedFile != null)
                learning.Image = savedFile.File;
            return _learningRepository.UpdateLearning(learning);
        }

        public LearningDto GetLearning(Guid learningId)
        {
            var comments = _commentService.GetCommentNumber(TableType.Learning);
            var likeViews = _likeViewService.GetLikeView(TableType.Learning);
            var likeViewAggregation = likeViews.GroupBy(x => x.TableId).Select(x => new
            {
                Id = x.Key,
                ViewCount = x.Count(v => v.LikeViewType == LikeViewType.View),
                LikeCount = x.Count(l => l.LikeViewType == LikeViewType.Like)
            });

            var rates = _rateScoreService.GetRate(TableType.Learning);
            var rateAverages = rates.GroupBy(x => x.TableId).Select(x => new
            {
                Id = x.Key,
                rateAverage = Math.Round(x.Average(rateScore => rateScore.Rate) * 2, MidpointRounding.AwayFromZero) / 2
            });

            var learnings = _learningRepository.Find(x => x.Id == learningId);
            var learningDtos = from learn in learnings
                join likeView in likeViewAggregation on learn.Id equals likeView.Id into lv
                from likeView in lv.DefaultIfEmpty()
                join rateAverage in rateAverages on learn.Id equals rateAverage.Id into rv
                from rateAverage in rv.DefaultIfEmpty()
                join commentNumber in comments on learn.Id equals commentNumber.Key into cn
                from commentNumber in cn.DefaultIfEmpty()
                select LearningDto.GetDto(learn, likeView?.LikeCount, likeView?.ViewCount, rateAverage?.rateAverage,
                    commentNumber.Value);
            return learningDtos.FirstOrDefault();
        }

        public DataTransferObject<LearningDto> GetSearch(DataTransferObject<LearningDto> dataTransferObject)
        {
            return _learningRepository.GetSearch(dataTransferObject);
        }

        public DataTransferObject<LearningDto> GetMyLearning(DataTransferObject<LearningDto> dataTransferObject)
        {
            return _learningRepository.GetMyLearning(dataTransferObject);
        }


        public DataTransferObject<LearningDto> GetMainPageLearning(DataTransferObject<LearningDto> dataTransferObject)
        {
            var mainPage = _learningRepository.GetMainPageLearning(dataTransferObject);

            foreach (var learnDto in mainPage.Result.Where<LearningDto>(learn => learn.Rate != null))
                learnDto.Rate = Math.Round(learnDto.Rate.Value * 2, MidpointRounding.AwayFromZero) / 2;

            return mainPage;
        }
    }
}