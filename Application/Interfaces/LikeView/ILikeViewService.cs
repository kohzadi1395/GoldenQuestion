
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;
using Application.DTOs.ReportDTO;

namespace Application.Interfaces.LikeView
{
    public partial interface ILikeViewService
    {
       IEnumerable<LikeViewDto> GetAllLikeViews();
       Domain.Entities.LikeView GetLikeView(Guid id);
       Domain.Entities.LikeView AddLikeView(Domain.Entities.LikeView likeView, Expression<Func<Domain.Entities.LikeView, bool>> predicate = null);
       bool RemoveLikeView(Expression<Func<Domain.Entities.LikeView, bool>> predicate);
       bool RemoveLikeView(Domain.Entities.LikeView likeView);
       bool UpdateLikeView(Domain.Entities.LikeView likeView);
       IEnumerable<Domain.Entities.LikeView> Find(Expression<Func<Domain.Entities.LikeView, bool>> criteria);
    }
}