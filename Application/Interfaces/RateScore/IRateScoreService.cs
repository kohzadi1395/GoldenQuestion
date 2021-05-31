
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces.RateScore
{
    public partial interface IRateScoreService
    {
       IEnumerable<RateScoreDto> GetAllRateScores();
       Domain.Entities.RateScore GetRateScore(Guid id);
       Domain.Entities.RateScore AddRateScore(Domain.Entities.RateScore rateScore, Expression<Func<Domain.Entities.RateScore, bool>> predicate = null);
       bool RemoveRateScore(Expression<Func<Domain.Entities.RateScore, bool>> predicate);
       bool RemoveRateScore(Domain.Entities.RateScore rateScore);
       bool UpdateRateScore(Domain.Entities.RateScore rateScore);
       IEnumerable<Domain.Entities.RateScore> Find(Expression<Func<Domain.Entities.RateScore, bool>> criteria);
    }
}