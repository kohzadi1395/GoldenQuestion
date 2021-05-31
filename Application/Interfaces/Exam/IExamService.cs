using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;
using Application.DTOs.ReportDTO;

namespace Application.Interfaces.Exam
{
    public partial interface IExamService
    {
        IEnumerable<ExamDto> GetAllExams(PaginationDto paginationDto);
        Domain.Entities.Exam GetExam(Guid id);

        Domain.Entities.Exam AddExam(Domain.Entities.Exam exam,
            Expression<Func<Domain.Entities.Exam, bool>> predicate = null);

        bool RemoveExam(Expression<Func<Domain.Entities.Exam, bool>> predicate);
        bool RemoveExam(Domain.Entities.Exam exam);
        bool UpdateExam(Domain.Entities.Exam exam);
        IEnumerable<Domain.Entities.Exam> Find(Expression<Func<Domain.Entities.Exam, bool>> criteria);
        ExamMongo TakeExam(Guid examId);
    }
}