using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Security.Application;

namespace Domain.Entities
{
    public class State : BaseEntity
    {
        public State()
        {
            Questions = new HashSet<Question>();
            Learnings = new HashSet<Learning>();
        }

        public string Name { get; set; }

        [ForeignKey("Country")] public Guid CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Learning> Learnings { get; set; }
    }
}