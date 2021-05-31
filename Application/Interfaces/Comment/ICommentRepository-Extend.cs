using System;
using System.Collections.Generic;
using Application.DTOs;
using Application.DTOs.ReportDTO;
using Domain.Entities;

namespace Application.Interfaces.Comment
{
    public partial interface ICommentRepository
    {
        Dictionary<Guid, int> CountComment(TableType tableType);
    }
}