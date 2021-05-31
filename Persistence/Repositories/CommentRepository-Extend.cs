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
        public Dictionary<Guid,int> CountComment(TableType tableType)
        {
            return _context.Comments.Where(x=>x.TableType== tableType && x.Deleted==false).GroupBy(x => x.TableId).Select(x => new
            {
                Id = x.Key,
                Count = x.Count(),
            }).ToDictionary(x=>x.Id,y=>y.Count);
        }
    }
}
