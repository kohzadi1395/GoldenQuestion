using Domain.Entities;

namespace Application.DTOs
{
    public class LanguageDto : Language
    {
        public Language Mapper()
        {
            return new Language
            {
                Abbreviation = Abbreviation,
                CreateDate = CreateDate,
                CreateUser = CreateUser,
                Deleted = Deleted,
                Icon = Icon,
                Id = Id,
                Learnings = Learnings,
                ModifyDate = ModifyDate,
                ModifyUser = ModifyUser,
                Name = Name,
                Questions = Questions,
                RightToLeft = RightToLeft,
                RowVersion = RowVersion
            };
        }

        public static LanguageDto GetDto(Language language)
        {
            return new LanguageDto
            {
                Abbreviation = language.Abbreviation,
                CreateDate = language.CreateDate,
                CreateUser = language.CreateUser,
                Deleted = language.Deleted,
                Icon = language.Icon,
                Id = language.Id,
                Learnings = language.Learnings,
                ModifyDate = language.ModifyDate,
                ModifyUser = language.ModifyUser,
                Name = language.Name,
                Questions = language.Questions,
                RightToLeft = language.RightToLeft,
                RowVersion = language.RowVersion
            };
        }
    }
}