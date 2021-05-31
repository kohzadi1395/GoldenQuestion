using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.ReportDTO;

namespace Application.Interfaces.Exam
{
    public partial interface IExamService
    {
        ExamMongo GetAnExams(int questionNumber, Guid userId);

        DataTransferObject<ExamDto> GetMainPageExam(DataTransferObject<ExamDto> dataTransferObject);

        IEnumerable<ExamDto> GetTakenExams(Guid userId);

        DataTransferObject<ExamDto> GetDraftExams(DataTransferObject<ExamDto> examinerId);

        DataTransferObject<ExamDto> GetMyExam(DataTransferObject<ExamDto> dataTransferObject);

        Task<Domain.Entities.Exam> AddExam(ExamDto exam, Expression<Func<Domain.Entities.Exam, bool>> predicate = null);
        
        Task<bool> UpdateExam(ExamDto examDto);

        ExamQuestionsDto GetExamQuestionOption(Guid examId);
       
        DataTransferObject<ExamDto> GetSearch(DataTransferObject<ExamDto> dataTransferObject);
    }
}