using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.ReportDTO;
using Domain.Entities;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public partial class ExamRepository
    {
        public IEnumerable<ExamDto> GetTakenExams(Guid userId)
        {
            return _context.Exams
                .AsNoTracking()
                .Where(x => x.Deleted == false && x.IsPublish && x.ExamTakens.Any(y => y.UserId == userId))
                .Include(x => x.ExamTakens)
                .Include(x => x.ExamQuestions)
                .Select(x => ExamDto.GetDto(x))
                .ToList();
        }

        public IEnumerable<ExamDto> GetGivenExams(Guid examinerId)
        {
            var examDtos = _context.Exams
                .AsNoTracking()
                .Where(x => x.Deleted == false && x.IsPublish && x.CreateUser == examinerId)
                .Select(x => ExamDto.GetDto(x))
                .ToList();
            return examDtos;
        }

        public ExamQuestionsDto GetExamQuestionOption(Guid examId)
        {
            var exam = GetAllExamQuestionOption(x => x.Id == examId).Result.FirstOrDefault();
            var examQuestionsDto = new ExamQuestionsDto();
            if (exam == null)
                return examQuestionsDto;

            examQuestionsDto.Questions =
                exam.ExamQuestions.Where(x => x.Deleted == false).Select(y => y.Question).ToList();
            exam.ExamQuestions = null;
            examQuestionsDto.Exam = ExamDto.GetDto(exam);

            return examQuestionsDto;
        }

        public ExamMongo GetMongoExamQuestionOption(Guid examId)
        {
            var exam = GetAllExamQuestionOption(x => x.Id == examId).Result.FirstOrDefault();

            var examMongo = new ExamMongo
            {
                Id = Guid.NewGuid(),
                Exam = exam,
                Questions = exam.ExamQuestions.Where(x => x.Deleted == false).Select(x =>
                {
                    x.Question.ExamQuestions = null;
                    return new QuesDto
                    {
                        Id = x.Question.Id,
                        Question = x.Question,
                        UserAnswer = null,
                        UserAnswers = null,
                        IsCorrect = false,
                        Options = x.Question.Options.Select(y =>
                        {
                            y.Question = null;
                            return new OpDto
                            {
                                Id = y.Id,
                                Option = y,
                                IsSelected = false
                            };
                        }).ToList()
                    };
                }).ToList(),
                CorrectAnswer = 0,
                WrongAnswer = 0,
                PercentCorrectAnswer = 0,
                PercentWrongAnswer = 0
            };
            exam.ExamQuestions = null;
            examMongo.StartDate = DateTime.Now;
            return examMongo;
        }

        public IEnumerable<ExamDto> GetAllExams(Guid userId)
        {
            return _context.Exams
                .AsNoTracking()
                .Where(x => x.Deleted == false)
                .Include(x => x.ExamQuestions)
                .Select(ExamDto.GetDto).ToList();
        }

        public DataTransferObject<ExamDto> GetDraftExams(DataTransferObject<ExamDto> dataTransferObject)
        {
            var exams = _context.Exams
                .Where(x => x.Deleted == false)
                .Where(x => x.IsPublish == false)
                .Where(x => x.ProjectId == dataTransferObject.FilterDto.ProjectId)
                .Select(exam => new Exam
                {
                    Cost = exam.Cost,
                    CreateDate = exam.CreateDate,
                    CreateUser = exam.CreateUser,
                    Deleted = exam.Deleted,
                    Description = exam.Description,
                    Id = exam.Id,
                    IsFree = exam.IsFree,
                    IsPublic = exam.IsPublic,
                    IsPublish = exam.IsPublish,
                    Logo = exam.Logo,
                    Name = exam.Name,
                    ProjectId = exam.ProjectId,
                    ShowLogo = exam.ShowLogo,
                    ScheduleDateFirst = exam.ScheduleDateFirst,
                    ScheduleTimeFirst = exam.ScheduleTimeFirst,
                    ScheduleDateSecond = exam.ScheduleDateSecond,
                    ScheduleTimeSecond = exam.ScheduleTimeSecond,
                    Tags = exam.Tags
                });
            var examDto = AdditionalInformation(exams, dataTransferObject);
            dataTransferObject.Result = examDto.Result;

            return dataTransferObject;
        }

        public DataTransferObject<ExamDto> GetMainPageExam(DataTransferObject<ExamDto> dataTransferObject)
        {
            var exams = _context.Exams
                .Where(x => x.Deleted == false)
                .Where(x => x.IsPublish)
                .Where(x => x.ProjectId == dataTransferObject.FilterDto.ProjectId)
                .Select(exam => new Exam
                {
                    Cost = exam.Cost,
                    CreateDate = exam.CreateDate,
                    CreateUser = exam.CreateUser,
                    Deleted = exam.Deleted,
                    Description = exam.Description,
                    Id = exam.Id,
                    IsFree = exam.IsFree,
                    IsPublic = exam.IsPublic,
                    IsPublish = exam.IsPublish,
                    Logo = exam.Logo,
                    Name = exam.Name,
                    ProjectId = exam.ProjectId,
                    ShowLogo = exam.ShowLogo,
                    ScheduleDateFirst = exam.ScheduleDateFirst,
                    ScheduleTimeFirst = exam.ScheduleTimeFirst,
                    ScheduleDateSecond = exam.ScheduleDateSecond,
                    ScheduleTimeSecond = exam.ScheduleTimeSecond,
                    Tags = exam.Tags
                });
            var examDto = AdditionalInformation(exams, dataTransferObject);
            dataTransferObject.Result = examDto.Result;

            return dataTransferObject;
        }

        public DataTransferObject<ExamDto> GetMyExam(DataTransferObject<ExamDto> dataTransferObject)
        {
            var exams = _context.Exams
                .Where(x => x.Deleted == false)
                .Where(x => x.IsPublish)
                .Where(x => x.ProjectId == dataTransferObject.FilterDto.ProjectId)
                .Where(x => x.CreateUser == dataTransferObject.FilterDto.UserId)
                .Select(exam => new Exam
                {
                    Cost = exam.Cost,
                    CreateDate = exam.CreateDate,
                    CreateUser = exam.CreateUser,
                    Deleted = exam.Deleted,
                    Description = exam.Description,
                    Id = exam.Id,
                    IsFree = exam.IsFree,
                    IsPublic = exam.IsPublic,
                    IsPublish = exam.IsPublish,
                    Logo = exam.Logo,
                    Name = exam.Name,
                    ProjectId = exam.ProjectId,
                    ShowLogo = exam.ShowLogo,
                    Tags = exam.Tags
                });
            var examDto = AdditionalInformation(exams, dataTransferObject);
            dataTransferObject.Result = examDto.Result;
            return dataTransferObject;
        }

        public DataTransferObject<ExamDto> GetSearch(DataTransferObject<ExamDto> dataTransferObject)
        {
            var exams = _context.Exams
                .Where(x => x.Deleted == false)
                .Where(x => x.ProjectId == dataTransferObject.FilterDto.ProjectId)
                .Where(x => x.IsPublish);

            var predicate = PredicateBuilder.False<Exam>();
            
            if (dataTransferObject.FilterDto.Tags != null)
            {
                foreach (var keyword in dataTransferObject.FilterDto.Tags.Split(new[] { ",", ";" },
                    StringSplitOptions.None))
                    predicate = predicate.Or(p => p.Tags.Contains(keyword.Trim()));
            }

            if (string.IsNullOrEmpty(dataTransferObject.FilterDto.Title) == false)
                predicate = predicate.Or(x => x.Name.Contains(dataTransferObject.FilterDto.Title));
            
            if (string.IsNullOrEmpty(dataTransferObject.FilterDto.Content) == false)
                predicate = predicate.Or(x => x.Description.Contains(dataTransferObject.FilterDto.Content));

            exams = exams.Where(predicate);


            var examDto = AdditionalInformation(exams, dataTransferObject);
            dataTransferObject.Result = examDto.Result;

            return dataTransferObject;
        }

        private async Task<IEnumerable<Exam>> GetAllExamQuestionOption(Expression<Func<Exam, bool>> criteria)
        {
            //var examQuestions = _context.ExamQuestions
            //    .Where(x => x.Deleted == false)
            //    .Include(eq => eq.Exam)
            //    .Where(x => x.Deleted == false)
            //    .Include(eq => eq.Question)
            //    .ThenInclude(x => x.Options)
            //    .Where(x => x.Deleted == false)

            //    .AsNoTracking()
            //    .ToListAsync();
            var exams = await _context.Exams
                .AsNoTracking()
                .Where(x => x.Deleted == false)
                .Where(criteria)
                .Include(x => x.ExamQuestions)
                .ThenInclude(x => x.Question)
                .ThenInclude(x => x.Options)
                .Where(x => x.ExamQuestions.Any(y => y.Deleted == false))
                .ToListAsync();
            return exams;
        }

        private Task<List<ExamDto>> AdditionalInformation(IQueryable<Exam> exams, DataTransferObject<ExamDto> dataTransferObject)
        {
            var rateQueries = _context.RateScores.Where(x => x.Deleted == false && x.TableType == TableType.Exam)
                .GroupBy(x => x.TableId).Select(x => new
                {
                    TableId = x.Key,
                    Average = x.Average(c => c.Rate)
                    //Math.Round(x.Average(rateScore => rateScore.Rate) * 2, MidpointRounding.AwayFromZero) / 2
                });
            var viewQueries = _context.LikeViews.Where(x => x.Deleted == false && x.TableType == TableType.Exam)
                .Where(c => c.LikeViewType == LikeViewType.View).GroupBy(x => x.TableId).Select(x => new
                {
                    TableId = x.Key,
                    View = x.Count()
                });
            var likeQueries = _context.LikeViews.Where(x => x.Deleted == false && x.TableType == TableType.Exam)
                .Where(c => c.LikeViewType == LikeViewType.Like).GroupBy(x => x.TableId).Select(x => new
                {
                    TableId = x.Key,
                    Like = x.Count()
                });

            var commentQueries = _context.Comments.Where(x => x.Deleted == false && x.TableType == TableType.Exam)
                .GroupBy(x => x.TableId).Select(x => new
                {
                    TableId = x.Key,
                    commentNumber = x.Count()
                });

            var examDtos = from exam in exams
                           join like in likeQueries on exam.Id equals like.TableId into examLike
                           from like in examLike.DefaultIfEmpty()
                           join view in viewQueries on exam.Id equals view.TableId into examView
                           from view in examView.DefaultIfEmpty()
                           join rate in rateQueries on exam.Id equals rate.TableId into examRate
                           from rate in examRate.DefaultIfEmpty()
                           join commentNumber in commentQueries on exam.Id equals commentNumber.TableId into
                               examCommentNumber
                           from commentNumber in examCommentNumber.DefaultIfEmpty()
                           select ExamDto.GetDto(exam,
                               like.Like,
                               view.View,
                               rate.Average,
                               commentNumber.commentNumber);

            var list = PagedResult(examDtos, dataTransferObject, x => x.CreateDate, false).ToListAsync();

            return list;
        }
    }
}