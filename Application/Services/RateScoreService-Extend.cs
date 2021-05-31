
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
    public partial class RateScoreService 
    {
        private readonly IMemoryCache _memoryCache;
       
        public IEnumerable<RateScore> GetRate(TableType tableType)
        {
            if (_memoryCache.TryGetValue("RateScore", out List<RateScore> tmpList))
                return tmpList;

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromHours(1));

             tmpList = Find(x => x.TableType == tableType).ToList();
            _memoryCache.Set("RateScore", tmpList, cacheEntryOptions);
            return tmpList;
        }

        public IEnumerable<RateScore> GetRate(TableType tableType, Guid id)
        {
            if (_memoryCache.TryGetValue(id, out List<RateScore> tmpList))
                return tmpList;

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromHours(1));

             tmpList = Find(x => x.TableType == tableType && x.TableId==id).ToList();
            _memoryCache.Set(id, tmpList, cacheEntryOptions);
            return tmpList;
        }
    }
}