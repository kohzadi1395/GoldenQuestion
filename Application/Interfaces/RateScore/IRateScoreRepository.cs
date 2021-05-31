
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.General;

namespace Application.Interfaces.RateScore
{
        public partial interface IRateScoreRepository : IRepository<Domain.Entities.RateScore>
        {
            IEnumerable<Domain.Entities.RateScore> GetAllRateScores();
            Domain.Entities.RateScore GetRateScore(Guid id);
            Domain.Entities.RateScore AddRateScore(Domain.Entities.RateScore rateScore, Expression<Func<Domain.Entities.RateScore, bool>> predicate = null);
            bool RemoveRateScore(Expression<Func<Domain.Entities.RateScore, bool>> criteria);
            bool RemoveRateScore(Domain.Entities.RateScore rateScore);
            bool UpdateRateScore(Domain.Entities.RateScore rateScore);
    
        }
}