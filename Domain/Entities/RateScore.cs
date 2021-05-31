using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class RateScore : BaseEntity
    {
        public double Rate { get; set; }
        public Guid TableId { get; set; }
        public TableType TableType { get; set; }
    }
}