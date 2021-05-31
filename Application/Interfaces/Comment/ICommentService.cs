
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;

namespace Application.Interfaces.Comment
{
    public partial interface ICommentService
    {
       IEnumerable<CommentDto> GetAllComments();
       Domain.Entities.Comment GetComment(Guid id);
       Domain.Entities.Comment AddComment(Domain.Entities.Comment comment, Expression<Func<Domain.Entities.Comment, bool>> predicate = null);
       bool RemoveComment(Expression<Func<Domain.Entities.Comment, bool>> predicate);
       bool RemoveComment(Domain.Entities.Comment comment);
       bool UpdateComment(Domain.Entities.Comment comment);
       IEnumerable<Domain.Entities.Comment> Find(Expression<Func<Domain.Entities.Comment, bool>> criteria);
    }
}