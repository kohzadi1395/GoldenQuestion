using Application.DTOs;
using Application.Interfaces.General;

namespace Application.Interfaces.ExmDto
{
    public interface IExamMongoRepository : IMongoRepository<ExamMongo>
    {
    }
}