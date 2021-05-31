using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.ReportDTO;

namespace Application.Interfaces.Exam
{
    public partial interface IExamRepository
    {
        IEnumerable<ExamDto> GetAllExams(Guid userId);
        IEnumerable<ExamDto> GetTakenExams(Guid userId);
        IEnumerable<ExamDto> GetGivenExams(Guid examinerId);
        DataTransferObject<ExamDto> GetDraftExams(DataTransferObject<ExamDto> examinerId);

        ExamQuestionsDto GetExamQuestionOption(Guid examId);
        ExamMongo GetMongoExamQuestionOption(Guid examId);
        DataTransferObject<ExamDto> GetMainPageExam(DataTransferObject<ExamDto> dataTransferObject);

        DataTransferObject<ExamDto> GetMyExam(DataTransferObject<ExamDto> dataTransferObject);

        DataTransferObject<ExamDto> GetSearch(DataTransferObject<ExamDto> dataTransferObject);
    }
}