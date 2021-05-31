using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;

namespace Application.Interfaces.Tag
{
    public partial interface ITagService
    {
        IEnumerable<TagDto> GetAllTags();
        Domain.Entities.Tag GetTag(Guid id);

        Domain.Entities.Tag AddTag(Domain.Entities.Tag tag,
            Expression<Func<Domain.Entities.Tag, bool>> predicate = null);

        bool RemoveTag(Expression<Func<Domain.Entities.Tag, bool>> predicate);
        bool RemoveTag(Domain.Entities.Tag tag);
        bool UpdateTag(Domain.Entities.Tag tag);
        IEnumerable<Domain.Entities.Tag> Find(Expression<Func<Domain.Entities.Tag, bool>> criteria);
    }
}