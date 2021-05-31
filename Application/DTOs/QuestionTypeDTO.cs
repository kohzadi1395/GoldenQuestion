using Domain.Entities;

namespace Application.DTOs
{
    public class QuestionTypeDto : QuestionType
    {
        public QuestionType Mapper()
        {
            return new QuestionType
            {
                CreateDate = CreateDate,
                CreateUser = CreateUser,
                Deleted = Deleted,
                Id = Id,
                ModifyDate = ModifyDate,
                ModifyUser = ModifyUser,
                Name = Name,
                Questions = Questions,
                RowVersion = RowVersion
            };
        }

        public static QuestionTypeDto GetDto(QuestionType questionType)
        {
            return new QuestionTypeDto
            {
                CreateDate = questionType.CreateDate,
                CreateUser = questionType.CreateUser,
                Deleted = questionType.Deleted,
                Id = questionType.Id,
                ModifyDate = questionType.ModifyDate,
                ModifyUser = questionType.ModifyUser,
                Name = questionType.Name,
                Questions = questionType.Questions,
                RowVersion = questionType.RowVersion
            };
        }
    }
}