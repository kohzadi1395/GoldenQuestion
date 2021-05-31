using System.Collections.Generic;

namespace Application.Interfaces.Tag
{
    public partial interface ITagService
    {
        void AddTags(List<Domain.Entities.Tag> tags);
    }
}