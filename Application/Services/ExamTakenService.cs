using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.ExamTaken;
using Domain.Entities;

namespace Application.Services
{
    public class ExamTakenService : IExamTakenService
    {
        private readonly IExamTakenRepository _examTakenRepository;

        public ExamTakenService(IExamTakenRepository examTakenRepository)
        {
            _examTakenRepository = examTakenRepository;
        }

        public IEnumerable<ExamTakenDto> GetAllExamTakens()
        {
            var examTakens = _examTakenRepository.GetAll().Select(x => new ExamTakenDto
            {
                TakeExam = x.TakeExam,
                UserId = x.UserId,
                ExamId = x.ExamId,
                Exam = x.Exam,
                Id = x.Id,
                CreateUser = x.CreateUser,
                CreateDate = x.CreateDate,
                ModifyUser = x.ModifyUser,
                ModifyDate = x.ModifyDate,
                Deleted = x.Deleted,
                RowVersion = x.RowVersion
            });
            return examTakens;
        }

        public ExamTaken GetExamTaken(Guid id)
        {
            return _examTakenRepository.GetById(id);
        }

        public ExamTaken AddExamTaken(ExamTaken examTaken, Expression<Func<ExamTaken, bool>> predicate = null)
        {
            return _examTakenRepository.AddExamTaken(examTaken, predicate);
        }

        public bool RemoveExamTaken(ExamTaken examTaken)
        {
            return _examTakenRepository.RemoveExamTaken(examTaken);
        }

        public bool RemoveExamTaken(Expression<Func<ExamTaken, bool>> predicate)
        {
            return _examTakenRepository.RemoveExamTaken(predicate);
        }

        public bool UpdateExamTaken(ExamTaken examTaken)
        {
            return _examTakenRepository.UpdateExamTaken(examTaken);
        }

        public IEnumerable<ExamTaken> Find(Expression<Func<ExamTaken, bool>> criteria)
        {
            return _examTakenRepository.Find(criteria);
        }
    }
}