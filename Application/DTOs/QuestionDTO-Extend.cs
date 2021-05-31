using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
    public partial class QuestionDto
    {
        public Option UserAnswer { get; set; }
        public string Number { get; set; }
    }
}