using System;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Application.DTOs.ReportDTO
{
    public class FilterDto
    {
        public string Tags { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        
        [Required]
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public Guid TableId { get; set; }
    }
}