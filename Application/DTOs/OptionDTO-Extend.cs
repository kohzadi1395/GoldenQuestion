using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
    public partial class OptionDto
    {
        public IFormFile OptionImage { get; set; }
    }
}