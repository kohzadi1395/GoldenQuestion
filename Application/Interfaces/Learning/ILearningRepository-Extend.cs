using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.ReportDTO;
using Application.Interfaces.General;
using Application.QTO;

namespace Application.Interfaces.Learning
{
    public partial interface ILearningRepository
    {
        DataTransferObject<LearningDto> GetSearch(DataTransferObject<LearningDto> dataTransferObject);
        
        DataTransferObject<LearningDto> GetMainPageLearning(DataTransferObject<LearningDto> dataTransferObject);

        DataTransferObject<LearningDto> GetMyLearning(DataTransferObject<LearningDto> dataTransferObject);

        DataTransferObject<LearningDto> GetLearning(DataTransferObject<LearningDto> dataTransferObject);
    }
}