using System.Collections.Generic;
using Microsoft.Security.Application;

namespace Domain.Entities
{
    public class Country : BaseEntity
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public string Name { get; set; }

        public byte[] flag { get; set; }

        public ICollection<State> States { get; set; }
    }
}