using Domain.Entities;

namespace Application.DTOs
{
    public class RateScoreDto : RateScore
    {
        public RateScore Mapper()
        {
            return new RateScore
            {
                CreateDate = CreateDate,
                CreateUser = CreateUser,
                Deleted = Deleted,
                Id = Id,
                ModifyDate = ModifyDate,
                ModifyUser = ModifyUser,
                Rate = Rate,
                RowVersion = RowVersion,
                TableId = TableId,
                TableType = TableType
            };
        }

        public static RateScoreDto GetDto(RateScore rateScore)
        {
            return new RateScoreDto
            {
                CreateDate = rateScore.CreateDate,
                CreateUser = rateScore.CreateUser,
                Deleted = rateScore.Deleted,
                Id = rateScore.Id,
                ModifyDate = rateScore.ModifyDate,
                ModifyUser = rateScore.ModifyUser,
                Rate = rateScore.Rate,
                RowVersion = rateScore.RowVersion,
                TableId = rateScore.TableId,
                TableType = rateScore.TableType
            };
        }
    }
}