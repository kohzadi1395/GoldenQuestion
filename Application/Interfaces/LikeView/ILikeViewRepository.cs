
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.General;

namespace Application.Interfaces.LikeView
{
        public partial interface ILikeViewRepository : IRepository<Domain.Entities.LikeView>
        {
            IEnumerable<Domain.Entities.LikeView> GetAllLikeViews();
            Domain.Entities.LikeView GetLikeView(Guid id);
            Domain.Entities.LikeView AddLikeView(Domain.Entities.LikeView likeView, Expression<Func<Domain.Entities.LikeView, bool>> predicate = null);
            bool RemoveLikeView(Expression<Func<Domain.Entities.LikeView, bool>> criteria);
            bool RemoveLikeView(Domain.Entities.LikeView likeView);
            bool UpdateLikeView(Domain.Entities.LikeView likeView);
    
        }
}