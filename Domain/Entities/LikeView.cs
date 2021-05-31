using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class LikeView:BaseEntity
    {
        public Guid TableId { get; set; }

        //Learning,Exam
        public TableType TableType { get; set; }

        //Like,View
        public LikeViewType LikeViewType { get; set; }
        
    }

    public enum LikeViewType
    {
        Like=1,
        View
    }

    public enum TableType
    {
        Learning=1,
        Exam
    }
}