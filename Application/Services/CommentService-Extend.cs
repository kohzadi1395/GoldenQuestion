using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.Exam;
using Application.Interfaces.Learning;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.Services
{
    public partial class CommentService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;
        public Dictionary<Guid, int> GetCommentNumber(TableType tableType)
        {
            if (_memoryCache.TryGetValue("CommentNumber", out Dictionary<Guid, int> tmpList))
                return tmpList;

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

             tmpList = _commentRepository.CountComment(tableType);
            _memoryCache.Set("CommentNumber", tmpList, cacheEntryOptions);
            return tmpList;
        }

        public async Task<List<UserDto>> GetComments(Guid tableId, IConfiguration configuration)
        {
            var comments = _commentRepository.Find(x => x.TableId == tableId).ToList();
            var userComment =await GetUserComment(comments);
            var users = from user in userComment
                           join comment in comments on user.Id equals comment.CreateUser into commt
                           from comment in commt.DefaultIfEmpty()
                select new UserDto
                           {
                               Id = user.Id,
                               FirstName = user.FirstName,
                               LastName = user.LastName,
                               ProfileImage = user.ProfileImage,
                               GenderId = user.GenderId,
                               Comment = comment
                };
            return users.ToList();
        }

        public List<CommentDto> MyObjectComments(Guid currentUser)
        {
            //var myLearn = _learningRepository.Find(x => x.CreateUser == currentUser);
            //var myExam = _examRepository.Find(x => x.CreateUser == currentUser);
            //var comments = _commentRepository.Find(x =>
            //    myExam.Select(e => e.Id).Contains(x.TableId) || myLearn.Select(e => e.Id).Contains(x.TableId)).Select(CommentDto.GetDto).ToList();
            //return comments;
            return null;
        }

        public async Task<List<UserDto>> GetUserComment(List<Comment> comments)
        {
            var data = JsonConvert.SerializeObject(comments.Select(x=>x.CreateUser).ToList());

            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var apiAddress = _configuration["ApiAddress"];
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, apiAddress)
            {
                Content = content
            };
            var response = await new HttpClient().SendAsync(requestMessage);
            var result = response.Content.ReadAsStringAsync().Result;
            var deserializeObject = JsonConvert.DeserializeObject<List<UserDto>>(result);
            return deserializeObject;
        }

        public async Task<List<UserDto>> GetSummaryUsers(List<Guid> userId)
        {
            var data = JsonConvert.SerializeObject(userId);

            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var apiAddress = _configuration["ApiAddressGetSummaryUsers"];
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, apiAddress)
            {
                Content = content
            };
            var response = await new HttpClient().SendAsync(requestMessage);
            var result = response.Content.ReadAsStringAsync().Result;
            var deserializeObject = JsonConvert.DeserializeObject<List<UserDto>>(result);
            return deserializeObject;
        }

    }
}