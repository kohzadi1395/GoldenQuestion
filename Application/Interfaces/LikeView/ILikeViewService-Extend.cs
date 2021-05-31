using System;
using System.Collections.Generic;
using Application.DTOs.ReportDTO;
using Domain.Entities;

namespace Application.Interfaces.LikeView
{
    public partial interface ILikeViewService
    {
        bool GetLikeViewUser(LikeViewUser likeViewUser, Guid loginUser);
        bool RemoveLikeViewUser(LikeViewUser likeViewUser, Guid loginUser);
        IEnumerable<Domain.Entities.LikeView> GetLikeView(TableType tableType);
        IEnumerable<Domain.Entities.LikeView> GetLikeView(TableType tableType, Guid tableId);
    }
}