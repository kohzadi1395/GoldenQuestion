
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces.RateScore
{
    public partial interface IRateScoreService
    {
       IEnumerable<Domain.Entities.RateScore> GetRate(TableType tableType);
       IEnumerable<Domain.Entities.RateScore> GetRate(TableType tableType, Guid id);

    }
}