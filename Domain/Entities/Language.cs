using System.Collections.Generic;
using Microsoft.Security.Application;

namespace Domain.Entities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string Icon { get; set; }

        public bool RightToLeft { get; set; }

        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
        public ICollection<Learning> Learnings { get; set; } = new HashSet<Learning>();
    }
}