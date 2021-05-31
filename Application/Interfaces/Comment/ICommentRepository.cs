
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.General;

namespace Application.Interfaces.Comment
{
        public partial interface ICommentRepository : IRepository<Domain.Entities.Comment>
        {
            IEnumerable<Domain.Entities.Comment> GetAllComments();
            Domain.Entities.Comment GetComment(Guid id);
            Domain.Entities.Comment AddComment(Domain.Entities.Comment comment, Expression<Func<Domain.Entities.Comment, bool>> predicate = null);
            bool RemoveComment(Expression<Func<Domain.Entities.Comment, bool>> criteria);
            bool RemoveComment(Domain.Entities.Comment comment);
            bool UpdateComment(Domain.Entities.Comment comment);
    
        }
}