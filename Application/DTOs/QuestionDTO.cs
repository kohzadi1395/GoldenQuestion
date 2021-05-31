using Domain.Entities;

namespace Application.DTOs
{
    public partial class QuestionDto : Question
    {
        public Question Mapper()
        {
            return new Question
            {
                CreateDate = CreateDate,
                CreateUser = CreateUser,
                Deleted = Deleted,
                ExamQuestions = ExamQuestions,
                Html = Html,
                Id = Id,
                Language = Language,
                LanguageId = LanguageId,
                ModifyDate = ModifyDate,
                ModifyUser = ModifyUser,
                Options = Options,
                QuestionType = QuestionType,
                QuestionTypeId = QuestionTypeId,
                RowVersion = RowVersion,
                State = State,
                StateId = StateId,
                Tags = Tags,
            };
        }

        public static QuestionDto GetDto(Question question)
        {
            return new QuestionDto
            {
                CreateDate = question.CreateDate,
                CreateUser = question.CreateUser,
                Deleted = question.Deleted,
                ExamQuestions = question.ExamQuestions,
                Html = question.Html,
                Id = question.Id,
                Language = question.Language,
                LanguageId = question.LanguageId,
                ModifyDate = question.ModifyDate,
                ModifyUser = question.ModifyUser,
                Options = question.Options,
                QuestionType = question.QuestionType,
                QuestionTypeId = question.QuestionTypeId,
                RowVersion = question.RowVersion,
                State = question.State,
                StateId = question.StateId,
                Tags = question.Tags,
            };
        }
    }
}