using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.ReportDTO;
using Application.QTO;

namespace Application.Interfaces.Learning
{
    public partial interface ILearningService
    {
        Task<Domain.Entities.Learning> AddLearning(LearningDto learning);
        Task<bool> UpdateLearning(LearningDto learning);

        DataTransferObject<LearningDto> GetMyLearning(DataTransferObject<LearningDto> dataTransferObject);

        DataTransferObject<LearningDto> GetMainPageLearning(DataTransferObject<LearningDto> dataTransferObject);
       
        LearningDto GetLearning(Guid learningId);

        DataTransferObject<LearningDto> GetSearch(DataTransferObject<LearningDto> dataTransferObject);
    }
}