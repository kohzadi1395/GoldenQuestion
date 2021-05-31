using System.Collections.Generic;
using Domain.Entities;

namespace Application.Services
{
    public partial class TagService
    {
        public void AddTags(List<Tag> tags)
        {
            _tagRepository.AddRange(tags);
        }
    }
}