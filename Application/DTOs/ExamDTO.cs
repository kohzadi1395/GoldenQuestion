
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Application.DTOs
{
    public partial class ExamDto : Exam
    {
        public Exam Mapper()
        {
            return new Exam
            {
				AllowComment = AllowComment,
				AllowContinuousLater = AllowContinuousLater,
				AllowCopy = AllowCopy,
				AllowCut = AllowCut,
				AllowPaste = AllowPaste,
				AllowPreviousQuestion = AllowPreviousQuestion,
				AllowPrint = AllowPrint,
				AllowRightClick = AllowRightClick,
				ConfirmCloseTab = ConfirmCloseTab,
				ConfirmSubmit = ConfirmSubmit,
				Cost = Cost,
				CreateDate = CreateDate,
				CreateUser = CreateUser,
				Deleted = Deleted,
				Description = Description,
				ExamQuestions = ExamQuestions,
				ExamTakens = ExamTakens,
				Id = Id,
				IsCommentNeedApprove = IsCommentNeedApprove,
				IsDisplayExamTitle = IsDisplayExamTitle,
				IsFree = IsFree,
				IsMaximumQuizAttempts = IsMaximumQuizAttempts,
				IsPageTimeLimits = IsPageTimeLimits,
				IsPublic = IsPublic,
				IsPublish = IsPublish,
				IsQuestionsPerPage = IsQuestionsPerPage,
				IsRandomOptions = IsRandomOptions,
				IsRandomQuestions = IsRandomQuestions,
				IsRedirectOnQuizCompletion = IsRedirectOnQuizCompletion,
				IsTimeLimited = IsTimeLimited,
				Logo = Logo,
				MaximumQuizAttempts = MaximumQuizAttempts,
				MinimumPassingScore= MinimumPassingScore,
				MaximumPassingScore= MaximumPassingScore,
				ModifyDate = ModifyDate,
				ModifyUser = ModifyUser,
				Name = Name,
				PageTimeLimits = PageTimeLimits,
				ProjectId = ProjectId,
				QuestionLayoutOption = QuestionLayoutOption,
				QuestionsPerPage = QuestionsPerPage,
				RedirectOnQuizCompletionOption = RedirectOnQuizCompletionOption,
				RedirectOnQuizCompletionToAnotherExam = RedirectOnQuizCompletionToAnotherExam,
				RedirectOnQuizCompletionToAnotherSite = RedirectOnQuizCompletionToAnotherSite,
				RedirectOnQuizCompletionUrl = RedirectOnQuizCompletionUrl,
				RowVersion = RowVersion,
				ScheduleDateFirst = ScheduleDateFirst,
				ScheduleDateSecond = ScheduleDateSecond,
				ScheduleTimeFirst = ScheduleTimeFirst,
				ScheduleTimeSecond = ScheduleTimeSecond,
				ShowCorrectAnswerAfterTheExam = ShowCorrectAnswerAfterTheExam,
				ShowCorrectAnswerSameMoment = ShowCorrectAnswerSameMoment,
				ShowLogo = ShowLogo,
				ShowProgress = ShowProgress,
				ShowQuestionNumber = ShowQuestionNumber,
				ShowResultAfterTheExam = ShowResultAfterTheExam,
				Tags = Tags,
				TimeLimited = TimeLimited

            };
        }
        public static ExamDto GetDto(Exam exam)
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
			        Id = exam.Id,
			        IsCommentNeedApprove = exam.IsCommentNeedApprove,
			        IsDisplayExamTitle = exam.IsDisplayExamTitle,
			        IsFree = exam.IsFree,
			        IsMaximumQuizAttempts = exam.IsMaximumQuizAttempts,
			        IsPageTimeLimits = exam.IsPageTimeLimits,
			        IsPublic = exam.IsPublic,
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
			        PageTimeLimits = exam.PageTimeLimits,
			        ProjectId = exam.ProjectId,
			        QuestionLayoutOption = exam.QuestionLayoutOption,
			        QuestionsPerPage = exam.QuestionsPerPage,
			        RedirectOnQuizCompletionOption = exam.RedirectOnQuizCompletionOption,
			        RedirectOnQuizCompletionToAnotherExam = exam.RedirectOnQuizCompletionToAnotherExam,
			        RedirectOnQuizCompletionToAnotherSite = exam.RedirectOnQuizCompletionToAnotherSite,
			        RedirectOnQuizCompletionUrl = exam.RedirectOnQuizCompletionUrl,
			        RowVersion = exam.RowVersion,
			        ScheduleDateFirst = exam.ScheduleDateFirst,
			        ScheduleDateSecond = exam.ScheduleDateSecond,
			        ScheduleTimeFirst = exam.ScheduleTimeFirst,
			        ScheduleTimeSecond = exam.ScheduleTimeSecond,
			        ShowCorrectAnswerAfterTheExam = exam.ShowCorrectAnswerAfterTheExam,
			        ShowCorrectAnswerSameMoment = exam.ShowCorrectAnswerSameMoment,
			        ShowLogo = exam.ShowLogo,
			        ShowProgress = exam.ShowProgress,
			        ShowQuestionNumber = exam.ShowQuestionNumber,
			        ShowResultAfterTheExam = exam.ShowResultAfterTheExam,
			        Tags = exam.Tags,
			        CorrectAnswer = 0,
			        Picture = null,
			        WrongAnswer = 0,
			        PercentCorrectAnswer = 0,
			        UserEmail = null,
			        Questions = exam.ExamQuestions?.Select(y => y.Question).ToList(),
			        CommentNumber = null,
			        Like = null,
			        View = null,
			        Rate = null,
			        NumberOfQuestion = exam.ExamQuestions?.Count ?? 0,
			        TimeLimited = exam.TimeLimited,
		        };
        }
        
    }
}