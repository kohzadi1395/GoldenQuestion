using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.LikeView;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class LikeViewRepository : Repository<LikeView>, ILikeViewRepository
    {
        private readonly ApiContext _context;

        public LikeViewRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<LikeView> GetAllLikeViews()
        {
           


            return GetAll();
        }

        public LikeView GetLikeView(Guid id)
        {
            return GetById(id);
        }

        public LikeView AddLikeView(LikeView likeView, Expression<Func<LikeView, bool>> predicate = null)
        {
            Add(likeView, predicate);
            return likeView;
        }

        public bool RemoveLikeView(LikeView likeView)
        {
            try
            {
                Remove(likeView);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveLikeView(Expression<Func<LikeView, bool>> criteria)
        {
            try
            {
                Remove(criteria);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateLikeView(LikeView likeView)
        {
            try
            {
                Update(likeView);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}