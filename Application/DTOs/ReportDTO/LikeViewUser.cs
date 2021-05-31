using System;
using Domain.Entities;

namespace Application.DTOs.ReportDTO
{
    public class LikeViewUser
    {
        public Guid TableId { get; set; }

        // Learning,Exam
        public TableType TableType { get; set; }

        //Like,View
        public LikeViewType LikeViewType { get; set; }
    }
}