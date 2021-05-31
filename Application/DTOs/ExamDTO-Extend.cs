using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
    public partial class ExamDto
    {
        public int CorrectAnswer { get; set; }
        public IFormFile Picture { get; set; }
        public int WrongAnswer { get; set; }
        public decimal PercentCorrectAnswer { get; set; }
        public string UserEmail { get; set; }
        public ICollection<Question> Questions { get; set; }
        public int? CommentNumber { get; set; }
        public int? Like { get; set; }
        public int? View { get; set; }
        public double? Rate { get; set; }
        public int NumberOfQuestion { get; set; }

        public static ExamDto GetDto(Exam exam,
            int? likeCount,
            int? viewCount,
            double? rateAverage,
            int commentNumber)
        {
            return new ExamDto
            {
                AllowComment = exam.AllowComment,
                AllowContinuousLater = exam.AllowContinuousLater,
                AllowCopy = exam.AllowCopy,
                AllowCut = exam.AllowCut,
                AllowPaste = exam.AllowPaste,
                AllowPreviousQuestion = exam.AllowPreviousQuestion,
                AllowPrint = exam.AllowPrint,
                AllowRightClick = exam.AllowRightClick,
                ConfirmCloseTab = exam.ConfirmCloseTab,
                ConfirmSubmit = exam.ConfirmSubmit,
                Cost = exam.Cost,
                CreateDate = exam.CreateDate,
                CreateUser = exam.CreateUser,
                Deleted = exam.Deleted,
                Description = exam.Description,
                ExamQuestions = exam.ExamQuestions,
                ExamTakens = exam.ExamTakens,
                IsPublic = exam.IsPublic,
                Tags = exam.Tags,
                CorrectAnswer = 0,
                Picture = null,
                WrongAnswer = 0,
                PercentCorrectAnswer = 0,
                UserEmail = null,
                Questions = exam.ExamQuestions?.Select(y => y.Question).ToList(),
                Id = exam.Id,
                IsCommentNeedApprove = exam.IsCommentNeedApprove,
                IsDisplayExamTitle = exam.IsDisplayExamTitle,
                IsFree = exam.IsFree,
                IsMaximumQuizAttempts = exam.IsMaximumQuizAttempts,
                IsPageTimeLimits = exam.IsPageTimeLimits,
                IsPublish = exam.IsPublish,
                IsQuestionsPerPage = exam.IsQuestionsPerPage,
                IsRandomOptions = exam.IsRandomOptions,
                IsRandomQuestions = exam.IsRandomQuestions,
                IsRedirectOnQuizCompletion = exam.IsRedirectOnQuizCompletion,
                IsTimeLimited = exam.IsTimeLimited,
                Logo = exam.Logo,
                MaximumQuizAttempts = exam.MaximumQuizAttempts,
                MinimumPassingScore = exam.MinimumPassingScore,
                MaximumPassingScore = exam.MaximumPassingScore,
                ModifyDate = exam.ModifyDate,
                ModifyUser = exam.ModifyUser,
                Name = exam.Name,
                ShowResultAfterTheExam = exam.ShowResultAfterTheExam,
                ShowCorrectAnswerAfterTheExam = exam.ShowCorrectAnswerAfterTheExam,
                ShowCorrectAnswerSameMoment = exam.ShowCorrectAnswerSameMoment,
                RedirectOnQuizCompletionToAnotherSite = exam.RedirectOnQuizCompletionToAnotherSite,
                RedirectOnQuizCompletionToAnotherExam = exam.RedirectOnQuizCompletionToAnotherExam,
                PageTimeLimits = exam.PageTimeLimits,
                QuestionLayoutOption = exam.QuestionLayoutOption,
                QuestionsPerPage = exam.QuestionsPerPage,
                RedirectOnQuizCompletionOption = exam.RedirectOnQuizCompletionOption,
                RedirectOnQuizCompletionUrl = exam.RedirectOnQuizCompletionUrl,
                RowVersion = exam.RowVersion,
                ScheduleDateFirst = exam.ScheduleDateFirst,
                ScheduleDateSecond = exam.ScheduleDateSecond,
                ScheduleTimeFirst = exam.ScheduleTimeFirst,
                ScheduleTimeSecond = exam.ScheduleTimeSecond,
                ShowLogo = exam.ShowLogo,
                ShowProgress = exam.ShowProgress,
                ShowQuestionNumber = exam.ShowQuestionNumber,
                TimeLimited = exam.TimeLimited,
                Rate = rateAverage ?? 0,
                NumberOfQuestion = exam.ExamQuestions?.Count ?? 0,
                Like = likeCount ?? 0,
                View = viewCount ?? 0,
                CommentNumber = commentNumber,
                ProjectId = exam.ProjectId
            };
        }
    }
}