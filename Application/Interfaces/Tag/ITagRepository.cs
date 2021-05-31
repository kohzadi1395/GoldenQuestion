using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.General;

namespace Application.Interfaces.Tag
{
    public interface ITagRepository : IRepository<Domain.Entities.Tag>
    {
        IEnumerable<Domain.Entities.Tag> GetAllTags();
        Domain.Entities.Tag GetTag(Guid id);

        Domain.Entities.Tag AddTag(Domain.Entities.Tag tag,
            Expression<Func<Domain.Entities.Tag, bool>> predicate = null);

        bool RemoveTag(Expression<Func<Domain.Entities.Tag, bool>> criteria);
        bool RemoveTag(Domain.Entities.Tag tag);
        bool UpdateTag(Domain.Entities.Tag tag);
    }
}