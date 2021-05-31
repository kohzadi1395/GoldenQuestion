
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.LikeView;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services
{
    public partial class LikeViewService : ILikeViewService
    {
        private readonly ILikeViewRepository _likeViewRepository;

        public LikeViewService(ILikeViewRepository likeViewRepository, IMemoryCache memoryCache)
        {
            _likeViewRepository = likeViewRepository;
            _memoryCache = memoryCache;
        }

        public IEnumerable<LikeViewDto> GetAllLikeViews()
        {
            var likeViews = _likeViewRepository.GetAll().Select(x => new LikeViewDto
            {
                Id = x.Id,
                TableId = x.TableId,
                TableType = x.TableType,
                CreateDate = x.CreateDate,
                LikeViewType = x.LikeViewType,
                CreateUser = x.CreateUser,
                ModifyUser = x.ModifyUser,
                ModifyDate = x.ModifyDate,
                Deleted = x.Deleted,
                RowVersion = x.RowVersion
            });
            return likeViews;
        }

        public LikeView GetLikeView(Guid id)
        {
            return _likeViewRepository.GetById(id);
        }

        public LikeView AddLikeView(LikeView likeView, Expression<Func<LikeView, bool>> predicate = null)
        {
            return _likeViewRepository.AddLikeView(likeView, predicate);
        }

        public bool RemoveLikeView(LikeView likeView)
        {
            return _likeViewRepository.RemoveLikeView(likeView);
        }

        public bool RemoveLikeView(Expression<Func<Domain.Entities.LikeView, bool>> predicate)
        {
            return _likeViewRepository.RemoveLikeView(predicate);
        }

        public bool UpdateLikeView(LikeView likeView)
        {
            return _likeViewRepository.UpdateLikeView(likeView);
        }
        public IEnumerable<LikeView> Find(Expression<Func<LikeView, bool>> criteria)
        {

            return _likeViewRepository.Find(criteria);
        }
        
    }
}