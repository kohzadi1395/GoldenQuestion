
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.Comment;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Application.Services
{
    public partial class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository, IMemoryCache memoryCache, IConfiguration configuration)
        {
            _commentRepository = commentRepository;
            _configuration = configuration;
            _memoryCache = memoryCache;
        }
        
        public IEnumerable<CommentDto> GetAllComments()
        {
            var comments = _commentRepository.GetAll().Select(CommentDto.GetDto);
            return comments;
        }

        public Comment GetComment(Guid id)
        {
            return _commentRepository.GetById(id);
        }

        public Comment AddComment(Comment comment, Expression<Func<Comment, bool>> predicate = null)
        {
            return _commentRepository.AddComment(comment, predicate);
        }

        public bool RemoveComment(Comment comment)
        {
            return _commentRepository.RemoveComment(comment);
        }

        public bool RemoveComment(Expression<Func<Domain.Entities.Comment, bool>> predicate)
        {
            return _commentRepository.RemoveComment(predicate);
        }

        public bool UpdateComment(Comment comment)
        {
            return _commentRepository.UpdateComment(comment);
        }

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> criteria)
        {
            return _commentRepository.Find(criteria);
        }
    }
}