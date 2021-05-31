using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public partial class ExamService
    {
        private readonly ICommentService _commentService;
        private readonly ILikeViewService _likeViewService;
        private readonly IRateScoreService _rateScoreService;
        private readonly IUtilities _utilities;


        public ExamMongo TakeExam(Guid examId)
        {
            var exam = _examRepository.GetMongoExamQuestionOption(examId);
            return exam;
        }

        public IEnumerable<ExamDto> GetTakenExams(Guid userId)
        {
            return _examRepository.GetTakenExams(userId);
        }

        public DataTransferObject<ExamDto> GetDraftExams(DataTransferObject<ExamDto> dataTransferObject)
        {
            return _examRepository.GetDraftExams(dataTransferObject);
        }

        public DataTransferObject<ExamDto>  GetMyExam(DataTransferObject<ExamDto> dataTransferObject)
        {
            return _examRepository.GetMyExam(dataTransferObject);
        }

        public ExamMongo GetAnExams(int questionNumber, Guid userId)
        {
            //var randomQuestions = _questionService.GetRandomQuestions(questionNumber).ToList();
            //var exam = new ExamDto
            //{
            //    Name = $"Exam {DateTime.Now:yyyy - MM - ddThh:mm:ssTZD}",
            //    NumberOfQuestion = randomQuestions.Count
            //};
            //_examRepository.AddExam(exam);
            //_examQuestionService.AddExamQuestion(exam.Id, randomQuestions);
            //return new ExamMongo
            //{
            //    Id = Guid.NewGuid(),
            //    UserId = userId,
            //    Name = $"Exam {DateTime.Now:yyyy - MM - ddThh:mm:ssTZD}",
            //    NumberOfQuestion = questionNumber,
            //    IsRandomExam = true,
            //    ExaminerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            //    QuesDtos = randomQuestions.Select(x => new QuesDto
            //    {
            //        Id = x.Id,
            //        Options = x.Options.Select(y => new OpDto
            //        {
            //            Id = y.Id,
            //            CorrectOption = y.CorrectOption
            //        }).ToList()
            //    }).ToList()
            //};
            return new ExamMongo();
        }


        public ExamQuestionsDto GetExamQuestionOption(Guid examId)
        {
            return _examRepository.GetExamQuestionOption(examId);
        }

        public DataTransferObject<ExamDto> GetSearch(DataTransferObject<ExamDto> dataTransferObject)
        {
            return _examRepository.GetSearch(dataTransferObject);
        }

        public DataTransferObject<ExamDto>  GetMainPageExam(DataTransferObject<ExamDto> dataTransferObject)
        {
            var mainPageExam = _examRepository.GetMainPageExam(dataTransferObject);
            foreach (var examDto in mainPageExam.Result.Where(examDto => examDto.Rate != null))
                examDto.Rate = Math.Round(examDto.Rate.Value * 2, MidpointRounding.AwayFromZero) / 2;

            return mainPageExam;
        }

        public IEnumerable<ExamDto> GetAllExams(PaginationDto paginationDto)
        {
            var takeNumber = GetTakeNumber();
            var comments = _commentService.GetCommentNumber(TableType.Exam);
            var likeViews = _likeViewService.GetLikeView(TableType.Exam);
            var likeViewAggregation = likeViews.GroupBy(x => x.TableId).Select(x => new
            {
                Id = x.Key,
                ViewCount = x.Count(v => v.LikeViewType == LikeViewType.View),
                LikeCount = x.Count(l => l.LikeViewType == LikeViewType.Like)
            });

            var rates = _rateScoreService.GetRate(TableType.Exam);
            var rateAverages = rates.GroupBy(x => x.TableId).Select(x => new
            {
                Id = x.Key,
                rateAverage = Math.Round(x.Average(rateScore => rateScore.Rate) * 2, MidpointRounding.AwayFromZero) / 2
            });
            var exams = _examRepository.GetAll();
            var examDtos = from exam in exams
                           join likeView in likeViewAggregation on exam.Id equals likeView.Id into lv
                           from likeView in lv.DefaultIfEmpty()
                           join rateAverage in rateAverages on exam.Id equals rateAverage.Id into rv
                           from rateAverage in rv.DefaultIfEmpty()
                           join commentNumber in comments on exam.Id equals commentNumber.Key into cn
                           from commentNumber in cn.DefaultIfEmpty()
                           select ExamDto.GetDto(exam, likeView?.LikeCount, likeView?.ViewCount, rateAverage?.rateAverage,
                               commentNumber.Value);
            return examDtos;
        }

        public Exam GetExam(Guid examId)
        {
            var exams = _examRepository.Find(x => x.Id == examId);
            var examDtos = from exam in exams
                           select ExamDto.GetDto(exam);
            return examDtos.FirstOrDefault();
        }

        public async Task<Exam> AddExam(ExamDto examDto, Expression<Func<Exam, bool>> predicate = null)
        {
            var exam = examDto.Mapper();
            var savedFile = await _utilities.GetImage(examDto.Id.ToString(), examDto.Picture);
            if (savedFile != null)
                exam.Logo = savedFile.File;
            var addedExam = _examRepository.AddExam(exam, predicate);
            return addedExam;
        }

        public async Task<bool> UpdateExam(ExamDto examDto)
        {
            var exam = examDto.Mapper();
            var savedFile = await _utilities.GetImage(examDto.Id.ToString(), examDto.Picture);
            if (savedFile != null)
                exam.Logo = savedFile.File;
            var updated = _examRepository.UpdateExam(exam);
            return updated;
        }

        private int GetTakeNumber()
        {
            return 0;
        }
    }
}