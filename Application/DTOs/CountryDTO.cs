using Domain.Entities;

namespace Application.DTOs
{
    public partial class CountryDto : Country
    {
        public Country Mapper()
        {
            return new Country
            {
                CreateDate = CreateDate,
                CreateUser = CreateUser,
                Deleted = Deleted,
                flag = flag,
                Id = Id,
                ModifyDate = ModifyDate,
                ModifyUser = ModifyUser,
                Name = Name,
                RowVersion = RowVersion,
                States = States
            };
        }

        public static CountryDto GetDto(Country country)
        {
            return new CountryDto
            {
                CreateDate = country.CreateDate,
                CreateUser = country.CreateUser,
                Deleted = country.Deleted,
                flag = country.flag,
                Id = country.Id,
                ModifyDate = country.ModifyDate,
                ModifyUser = country.ModifyUser,
                Name = country.Name,
                RowVersion = country.RowVersion,
                States = country.States
            };
        }
    }
}