using Domain.Entities;

namespace Application.DTOs
{
    public class TagDto : Tag
    {
        public Tag Mapper()
        {
            return new Tag
            {
                CreateDate = CreateDate,
                CreateUser = CreateUser,
                Deleted = Deleted,
                Id = Id,
                ModifyDate = ModifyDate,
                ModifyUser = ModifyUser,
                Name = Name,
                RowVersion = RowVersion
            };
        }

        public static TagDto GetDto(Tag tag)
        {
            return new TagDto
            {
                CreateDate = tag.CreateDate,
                CreateUser = tag.CreateUser,
                Deleted = tag.Deleted,
                Id = tag.Id,
                ModifyDate = tag.ModifyDate,
                ModifyUser = tag.ModifyUser,
                Name = tag.Name,
                RowVersion = tag.RowVersion
            };
        }
    }
}