using Domain.Entities;

namespace Application.DTOs
{
    public partial class OptionDto : Option
    {
        public Option Mapper()
        {
            return new Option
            {
                CorrectOption = CorrectOption,
                CreateDate = CreateDate,
                CreateUser = CreateUser,
                Deleted = Deleted,
                Html = Html,
                Id = Id,
                ModifyDate = ModifyDate,
                ModifyUser = ModifyUser,
                Question = Question,
                QuestionId = QuestionId,
                RowVersion = RowVersion
            };
        }

        public static OptionDto GetDto(Option option)
        {
            return new OptionDto
            {
                CorrectOption = option.CorrectOption,
                CreateDate = option.CreateDate,
                CreateUser = option.CreateUser,
                Deleted = option.Deleted,
                Html = option.Html,
                Id = option.Id,
                ModifyDate = option.ModifyDate,
                ModifyUser = option.ModifyUser,
                Question = option.Question,
                QuestionId = option.QuestionId,
                RowVersion = option.RowVersion
            };
        }
    }
}