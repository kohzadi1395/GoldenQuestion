using Domain.Entities;

namespace Application.DTOs
{
    public class LikeViewDto : LikeView
    {
        public LikeView Mapper()
        {
            return new LikeView
            {
                CreateDate = CreateDate,
                CreateUser = CreateUser,
                Deleted = Deleted,
                Id = Id,
                LikeViewType = LikeViewType,
                ModifyDate = ModifyDate,
                ModifyUser = ModifyUser,
                RowVersion = RowVersion,
                TableId = TableId,
                TableType = TableType
            };
        }

        public static LikeViewDto GetDto(LikeView likeView)
        {
            return new LikeViewDto
            {
                CreateDate = likeView.CreateDate,
                CreateUser = likeView.CreateUser,
                Deleted = likeView.Deleted,
                Id = likeView.Id,
                LikeViewType = likeView.LikeViewType,
                ModifyDate = likeView.ModifyDate,
                ModifyUser = likeView.ModifyUser,
                RowVersion = likeView.RowVersion,
                TableId = likeView.TableId,
                TableType = likeView.TableType
            };
        }
    }
}