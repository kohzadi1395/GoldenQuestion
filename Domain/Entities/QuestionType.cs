using System.Collections.Generic;
using Microsoft.Security.Application;

namespace Domain.Entities
{
    public class QuestionType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    }
}