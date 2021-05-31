using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.DTOs.ReportDTO
{
    public class DataTransferObject<T>
    {
        public FilterDto FilterDto { get; set; }
        public PaginationDto Pagination { get; set; }
        public List<T> Result { get; set; }
        public int TotalRow { get; set; }
    }
}