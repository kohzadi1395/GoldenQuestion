using Domain.Entities;

namespace Application.DTOs
{
    public class StateDto : State
    {
        public State Mapper()
        {
            return new State
            {
                Country = Country,
                CountryId = CountryId,
                CreateDate = CreateDate,
                CreateUser = CreateUser,
                Deleted = Deleted,
                Id = Id,
                Learnings = Learnings,
                ModifyDate = ModifyDate,
                ModifyUser = ModifyUser,
                Name = Name,
                Questions = Questions,
                RowVersion = RowVersion
            };
        }

        public static StateDto GetDto(State state)
        {
            return new StateDto
            {
                Country = state.Country,
                CountryId = state.CountryId,
                CreateDate = state.CreateDate,
                CreateUser = state.CreateUser,
                Deleted = state.Deleted,
                Id = state.Id,
                Learnings = state.Learnings,
                ModifyDate = state.ModifyDate,
                ModifyUser = state.ModifyUser,
                Name = state.Name,
                Questions = state.Questions,
                RowVersion = state.RowVersion
            };
        }
    }
}