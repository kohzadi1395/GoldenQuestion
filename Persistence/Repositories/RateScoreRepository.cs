using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.RateScore;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class RateScoreRepository : Repository<RateScore>, IRateScoreRepository
    {
        private readonly ApiContext _context;

        public RateScoreRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<RateScore> GetAllRateScores()
        {
            return GetAll();
        }

        public RateScore GetRateScore(Guid id)
        {
            return GetById(id);
        }

        public RateScore AddRateScore(RateScore rateScore, Expression<Func<RateScore, bool>> predicate = null)
        {
            Add(rateScore, predicate);
            return rateScore;
        }

        public bool RemoveRateScore(RateScore rateScore)
        {
            try
            {
                Remove(rateScore);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveRateScore(Expression<Func<RateScore, bool>> criteria)
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

        public bool UpdateRateScore(RateScore rateScore)
        {
            try
            {
                Update(rateScore,
                    x => x.TableId == rateScore.TableId
                         && x.TableType == rateScore.TableType
                         && x.CreateUser == rateScore.ModifyUser);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}