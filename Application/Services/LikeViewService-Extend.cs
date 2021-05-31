using Application.DTOs.ReportDTO;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public partial class LikeViewService
    {
        private readonly IMemoryCache _memoryCache;

        public bool GetLikeViewUser(LikeViewUser likeViewUser, Guid loginUser)
        {
            var likeView = _likeViewRepository.Find(x => x.TableId == likeViewUser.TableId
                                                         && x.CreateUser == loginUser
                                                         && x.LikeViewType == likeViewUser.LikeViewType
                                                         && x.TableType == likeViewUser.TableType).Any();
            return likeView;
        }

        public bool RemoveLikeViewUser(LikeViewUser likeViewUser, Guid loginUser)
        {
            try
            {
                _likeViewRepository.Remove(x => x.TableId == likeViewUser.TableId
                                                && x.CreateUser == loginUser
                                                && x.LikeViewType == likeViewUser.LikeViewType
                                                && x.TableType == likeViewUser.TableType);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<LikeView> GetLikeView(TableType tableType)
        {
            
            if (_memoryCache.TryGetValue("LikeView", out List<LikeView> tmpList))
                return tmpList;

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

             tmpList = Find(x => x.TableType == tableType).ToList();
            _memoryCache.Set("LikeView", tmpList, cacheEntryOptions);
            return tmpList;
        }
     
        public IEnumerable<LikeView> GetLikeView(TableType tableType, Guid tableId)
        {
            if (_memoryCache.TryGetValue(tableId, out List<LikeView> tmpList))
                return tmpList;

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

            tmpList = Find(x => x.TableType == tableType && x.TableId == tableId).ToList();
            _memoryCache.Set(tableId, tmpList, cacheEntryOptions);
            return tmpList;
        }
    }
}