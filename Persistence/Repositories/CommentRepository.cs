using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Interfaces.Comment;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public partial class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly ApiContext _context;

        public CommentRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return GetAll();
        }

        public Comment GetComment(Guid id)
        {
            return GetById(id);
        }

        public Comment AddComment(Comment comment, Expression<Func<Comment, bool>> predicate = null)
        {
            Add(comment, predicate);
            return comment;
        }

        public bool RemoveComment(Comment comment)
        {
            try
            {
                Remove(comment);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool RemoveComment(Expression<Func<Comment, bool>> criteria)
        {
            try
            {
                Remove(criteria);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public bool UpdateComment(Comment comment)
        {
            try
            {
                
                Update(comment);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
