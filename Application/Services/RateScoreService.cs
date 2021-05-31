
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.RateScore;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services
{
    public partial class RateScoreService : IRateScoreService
    {
        private readonly IRateScoreRepository _rateScoreRepository;

        public RateScoreService(IRateScoreRepository rateScoreRepository, IMemoryCache memoryCache)
        {
            _rateScoreRepository = rateScoreRepository;
            _memoryCache = memoryCache;
        }

        public IEnumerable<RateScoreDto> GetAllRateScores()
        {
            var rateScores = _rateScoreRepository.GetAll().Select(x => new RateScoreDto
            {
                Id = x.Id,
                Rate = x.Rate,
                TableId = x.TableId,
                TableType = x.TableType,
                CreateUser = x.CreateUser,
                CreateDate = x.CreateDate,
                ModifyUser = x.ModifyUser,
                ModifyDate = x.ModifyDate,
                Deleted = x.Deleted,
                RowVersion = x.RowVersion
            });
            return rateScores;
        }

        public RateScore GetRateScore(Guid id)
        {
            return _rateScoreRepository.GetById(id);
        }

        public RateScore AddRateScore(RateScore rateScore, Expression<Func<RateScore, bool>> predicate = null)
        {
            return _rateScoreRepository.AddRateScore(rateScore, predicate);
        }

        public bool RemoveRateScore(RateScore rateScore)
        {
            return _rateScoreRepository.RemoveRateScore(rateScore);
        }

        public bool RemoveRateScore(Expression<Func<Domain.Entities.RateScore, bool>> predicate)
        {
            return _rateScoreRepository.RemoveRateScore(predicate);
        }

        public bool UpdateRateScore(RateScore rateScore)
        {
            return _rateScoreRepository.UpdateRateScore(rateScore);
        }
        public IEnumerable<RateScore> Find(Expression<Func<RateScore, bool>> criteria)
        {
            return _rateScoreRepository.Find(criteria);
        }
    }
}