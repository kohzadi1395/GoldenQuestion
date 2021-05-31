using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Exam : BaseEntity
    {
        [Required] public string Name { get; set; }
        public bool? ShowResultAfterTheExam { get; set; } = false; 
        public bool? ShowCorrectAnswerAfterTheExam { get; set; } = false;
        public bool? ShowCorrectAnswerSameMoment { get; set; } = false;
        public bool? RedirectOnQuizCompletionToAnotherSite { get; set; } = false;
        public bool? RedirectOnQuizCompletionToAnotherExam { get; set; } = false;

        public string Description { get; set; }

        public bool IsRandomQuestions { get; set; }
        public bool IsRandomOptions { get; set; }
        public byte[] Logo { get; set; }
        public bool ShowLogo { get; set; }
        public bool ShowProgress { get; set; }
        public bool AllowContinuousLater { get; set; }
        public bool IsFree { get; set; }
        public bool IsPublish { get; set; }
        public decimal Cost { get; set; }
        public bool ShowQuestionNumber { get; set; }
        public bool AllowCut { get; set; }
        public bool AllowCopy { get; set; }
        public bool AllowPaste { get; set; }
        public bool AllowRightClick { get; set; }
        public bool AllowPrint { get; set; }
        public bool AllowPreviousQuestion { get; set; }
        public bool AllowComment { get; set; }
        public bool ConfirmSubmit { get; set; }
        public bool ConfirmCloseTab { get; set; }
        public bool IsCommentNeedApprove { get; set; }
        public Guid? ProjectId { get; set; }
        [MaxLength(5)] [MinLength(5)] public string TimeLimited { get; set; }

        public bool IsTimeLimited { get; set; }

        public int? MinimumPassingScore { get; set; }
        public int? MaximumPassingScore { get; set; }

        public bool IsDisplayExamTitle { get; set; }
        public bool IsQuestionsPerPage { get; set; }
        public int QuestionsPerPage { get; set; }
        public int MaximumQuizAttempts { get; set; }
        public bool IsMaximumQuizAttempts { get; set; }
        public bool IsRedirectOnQuizCompletion { get; set; }

        public string RedirectOnQuizCompletionOption { get; set; }

        public string RedirectOnQuizCompletionUrl { get; set; }

        // Vertical or Horizontal
        public bool QuestionLayoutOption { get; set; }
        public bool IsPageTimeLimits { get; set; }

        [MaxLength(5)] [MinLength(5)] public string PageTimeLimits { get; set; }

        public DateTime ScheduleDateFirst { get; set; }

        [MaxLength(5)] [MinLength(5)] public string ScheduleTimeFirst { get; set; }


        public DateTime ScheduleDateSecond { get; set; }

        [MaxLength(5)] [MinLength(5)] public string ScheduleTimeSecond { get; set; }

        public ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();
        public ICollection<ExamTaken> ExamTakens { get; set; } = new List<ExamTaken>();
        public bool IsPublic { get; set; }

        public string Tags { get; set; }
    }
}