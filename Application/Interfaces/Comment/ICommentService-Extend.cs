
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Interfaces.Comment
{
    public partial interface ICommentService
    {
        Dictionary<Guid, int> GetCommentNumber(TableType tableType);
        Task<List<UserDto>> GetComments(Guid tableId, IConfiguration configuration);
        List<CommentDto> MyObjectComments(Guid currentUser);
        Task<List<UserDto>> GetSummaryUsers(List<Guid> userId);
    }
}